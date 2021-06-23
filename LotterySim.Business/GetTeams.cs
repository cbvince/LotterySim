using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using LotterySim;
using System.Runtime.Caching;

namespace LotterySim.Business
{
    public class GetTeams
    {

     

        private static string GetTeamData()
        {
            var client = new RestClient("http://data.nba.net/10s/prod/v1/current/standings_all.json");
            client.Timeout = 20000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject(response.Content).ToString();

        }

        private static string GetTeamDataFromCache()
        {

            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains("teams"))
            {
                var teams = cache.GetCacheItem("teams").Value.ToString();
                return teams;
            }

            else
            {
                cache.Add("teams", GetTeamData(), DateTimeOffset.Now.AddMinutes(30));
                return GetTeamDataFromCache();
            }


            
        }

        private static List<Team> ConvertTeamData()
        {
            //string strJSON = GetTeamData();
            string strJSON = GetTeamDataFromCache();
            var teamdata = JsonConvert.DeserializeObject<dynamic>(strJSON);

      

            var teams = new List<Team>();

            {
                var i = 1;
                foreach (var team in teamdata.league.standard.teams)
                {
                    string teamName = team.teamSitesOnly.teamName;
                    
                    teams.Add(new Team()
                    {
                        
                        TeamName = team.teamSitesOnly.teamName,   
                        TeamID = team.teamId,
                        TeamNickName = team.teamSitesOnly.teamNickname,
                        OriginalTeamName = team.teamSitesOnly.teamName,
                        Wins = team.win,
                        Losses = team.loss,
                        WinLossRecord = team.win + "-" + team.loss,
                        WinPercentage = team.winPct,
                        GamesBack = team.gamesBehind,
                        LastTenGamesRecord = team.lastTenWin + "-" + team.lastTenLoss,
                        LastTenLosses = team.lastTenLoss,
                        LastTenWins = team.lastTenWin,
                        ConsecutiveWinLoss = team.streak,
                        WinorLossStreak = team.isWinStreak,
                        ConferenceRank = team.confRank,
                        TieBreakerGroupPosition = SetTieBreakerGroups(teamName),
                        TeamRank = i++

                    }) ;

                }

            };


            return teams;

        }
        public static List<Team> GetLotteryTeams()
        {
            var lotteryTeams = new List<Team>();
            var i = 14;
            var x = 30;
            foreach (var team in ConvertTeamData().Where(p => p.ConferenceRank > 8).OrderByDescending(p => p.Wins).ThenByDescending(p => p.TieBreakerGroupPosition))
                
                
            {
                team.TeamRank = i--;
                lotteryTeams.Add(team);
            }

            foreach (var team in ConvertTeamData().Where(p => p.ConferenceRank <= 8).OrderByDescending(p => p.Wins).ThenByDescending(p => p.TieBreakerGroupPosition))


            {
                team.TeamRank = x--;
                lotteryTeams.Add(team);
            }



            //lotteryTeams.Reverse();

            DetermineGamesBack(lotteryTeams);
            DetermineWinLossStreak(lotteryTeams);
            SetPickNumberFromRanking(lotteryTeams);
            AddTopFourPickOdds(lotteryTeams);
            AddTopOnePickOdds(lotteryTeams);
            GetTeamImages(lotteryTeams);
            PickProtections.PickProtection(lotteryTeams);
            return lotteryTeams;
        }

        private static void DetermineGamesBack(List<Team> teams)
        {
            
            var highestNumberOfLosses = teams.OrderByDescending(p => p.Losses).FirstOrDefault().Losses;
            var lowestNumberOfWins = teams.OrderBy(p => p.Wins).FirstOrDefault().Wins;
            var winLostDifferenceForWorstTeam =  highestNumberOfLosses - lowestNumberOfWins;
          

            foreach (var team in teams)
            {      
                var teamWinLossDifference = team.Losses - team.Wins;
  
                team.LotteryGamesBack = (winLostDifferenceForWorstTeam - teamWinLossDifference) / 2;
            }

            
        }

        private static void DetermineWinLossStreak(List<Team> teams)
        {
            foreach (var team in teams)
            {
            
                var streakType = (team.WinorLossStreak) ? "Won" : "Lost";
                var streakNumber = team.ConsecutiveWinLoss;
                var streak = streakType + " " + streakNumber.ToString();
                team.WinLossStreak = streak;

            }
        }

        private static void AddTopFourPickOdds(List<Team> teams)
        {
            foreach (var team in teams)
            {

                                 
                switch (team.TeamRank)
                {
                    case 1:
                    case 2:
                    case 3:
                        team.TopFourPickOdds = "52.1%";
                        break;
                    case 4:
                    case 5:
                         team.TopFourPickOdds = "45.1%";
                        break;
                    case 6:
                        team.TopFourPickOdds = "37.2%";
                        break;
                    case 7:
                        team.TopFourPickOdds = "31.9%";
                        break;
                    case 8:
                    case 9:
                    case 10:
                        team.TopFourPickOdds = "20.3%";
                        break;
                    case 11:
                        team.TopFourPickOdds = "8.5%";
                        break;
                    case 12:
                        team.TopFourPickOdds = "8.0%";
                        break;
                    case 13:
                        team.TopFourPickOdds = "4.8%";
                        break;
                    case 14:
                        team.TopFourPickOdds = "2.4%";
                        break;


                }
            }
        }

        private static void AddTopOnePickOdds(List<Team> teams)
        {
            foreach (var team in teams)
            {
                switch (team.TeamRank)
                {
                    case 1:
                    case 2:
                    case 3:
                        team.TopPickOdds = "14.0%";
                        break;
                    case 4:
                    case 5:
                        team.TopPickOdds = "11.5%";
                        break;
                    case 6:
                        team.TopPickOdds = "9.0%";
                        break;
                    case 7:
                        team.TopPickOdds = "7.5%";
                        break;
                    case 8:
                    case 9:
                    case 10:
                        team.TopPickOdds = "4.5%";
                        break;
                    case 11:
                        team.TopPickOdds = "1.8%";
                        break;
                    case 12:
                        team.TopPickOdds = "1.7%";
                        break;
                    case 13:
                        team.TopPickOdds = "1.0%";
                        break;
                    case 14:
                        team.TopPickOdds = "0.5%";
                        break;

                    
                }
            }
        }

        private static void SetPickNumberFromRanking(List<Team> teams)
        {
            foreach (var team in teams)
            {
                team.PickNumber = team.TeamRank;
            }
        }

        private static int SetTieBreakerGroups(string teamname)
        {
            var tieBreakerPosition = 0;
                
                    
                    switch (teamname)
                
                {
                    case "Chicago": tieBreakerPosition = 1;
                        break;
                    case "Sacramento":
                        tieBreakerPosition = 2;
                        break;
                    case "New Orleans":
                        tieBreakerPosition = 3;
                        break;
                case "Charlotte":
                    tieBreakerPosition = 4;
                    break;
                case "San Antonio":
                    tieBreakerPosition = 5;
                    break;
                case "New York":
                    tieBreakerPosition = 6;
                    break;
                case "Atlanta":
                    tieBreakerPosition = 7;
                    break;
                case "Dallas":
                    tieBreakerPosition = 8;
                    break;
                case "Los Angeles":
                    tieBreakerPosition = 9;
                    break;
                case "Portland":
                    tieBreakerPosition = 10;
                    break;
                case "LA":
                    tieBreakerPosition = 11;
                    break;
                case "Denver":
                    tieBreakerPosition = 12;
                    break;
                default:
                    tieBreakerPosition = 0;
                    break;
                        

                    
                
            }
            return tieBreakerPosition;
            
        }

        public static void SetPickNumberFromLotteryNumber(List<Team> teams)
        {
             foreach (var team in teams)
            {
                team.PickNumber = team.LotteryNumber;
            }
}

        public static void GetTeamImages(List<Team> teams)
        {

            var teamName = string.Empty;
            foreach (var team in teams)
               
            {
               teamName =  (team.NewTeamName == null) ? team.TeamName : team.NewTeamName;
                team.TeamImage = string.Format("~/Content/Images/{0}.svg", teamName.Replace(" ", ""));
              
            }
        }

        public static List<Team> OutGoingPicks(Team team)
        {
            return LotterySim.Business.GetTeams.GetLotteryTeams().Where(p => p.OriginalTeamName == team.OriginalTeamName && p.NewTeamName != null).ToList();
        }

        public static List<Team> IncomingPicks(Team team)
        {
            return LotterySim.Business.GetTeams.GetLotteryTeams().Where(p => (p.OriginalTeamName == team.OriginalTeamName && p.NewTeamName == null) || p.NewTeamName == team.OriginalTeamName).OrderBy(p => p.PickNumber).ToList();
        }

        public static List<Team> NonConveyedPicks(Team team)
        {
            return LotterySim.Business.GetTeams.GetLotteryTeams().Where(p => p.TeamPickOwedToName == team.OriginalTeamName && p.PickSwapType == PickSwapType.Protected).ToList();
        }

    }

     
}
