using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using LotterySim;


namespace LotterySim.Business
{
    public class GetTeams
    {

     

        private static string GetTeamData()
        {
            var client = new RestClient("http://data.nba.net/10s/prod/v1/current/standings_all.json");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "akacd_data_nba_net_ems=1621084730~rv=28~id=4da39e50afa2126a661150d0ddc688e8");
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject(response.Content).ToString();

        }

        private static List<Team> ConvertTeamData()
        {
            string strJSON = GetTeamData();
            var teamdata = JsonConvert.DeserializeObject<dynamic>(strJSON);

      

            var teams = new List<Team>();

            {
                var i = 1;
                foreach (var team in teamdata.league.standard.teams)
                {
                    //result += team.win + " " + team.loss + " " + team.teamSitesOnly.teamName + " " + team.teamSitesOnly.teamNickname + "</br>";
                    teams.Add(new Team()
                    {
                        TeamName = team.teamSitesOnly.teamName,
                        //+ " "
                        //+ team.teamSitesOnly.teamNickName,
                        OriginalTeamName = team.teamSitesOnly.teamName,
                        Wins = team.win,
                        Losses = team.loss,
                        WinLossRecord = team.win + "-" + team.loss,
                        WinPercentage = team.winPct,
                        GamesBack = team.gamesBehind,
                        LastTenGamesRecord = team.lastTenWin + "-" + team.lastTenLoss,
                        ConsecutiveWinLoss = team.streak,
                        WinorLossStreak = team.isWinStreak,
                        ConferenceRank = team.confRank,
                        TeamRank = i++

                    }) ;

                }

            };


            return teams;

        }

        public static List<Team> GetLotteryTeams()
        {
            var lotteryTeams = new List<Team>();
            int i = 14;
            foreach (var team in ConvertTeamData().Where(p => p.ConferenceRank > 8).OrderBy(p => p.ConferenceRank))
            {
                team.TeamRank = i--;
                lotteryTeams.Add(team);
            }

           
            lotteryTeams.Reverse();
            DetermineGamesBack(lotteryTeams);
            DetermineWinLossStreak(lotteryTeams);
            SetPickNumberFromRanking(lotteryTeams);
            AddTopFourPickOdds(lotteryTeams);
            AddTopOnePickOdds(lotteryTeams);
            PickProtections.PickProtection(lotteryTeams);
            return lotteryTeams;
        }

        private static void DetermineGamesBack(List<Team> teams)
        {
            var topGamesBehind = teams.FirstOrDefault().GamesBack;
            var leadingLotteryTeamWins = teams.FirstOrDefault().Wins;
            var leadingLotteryTeamLosses = teams.FirstOrDefault().Losses;
            var leadingLotteryTeamWinLossDifference = leadingLotteryTeamLosses - leadingLotteryTeamWins;



            foreach (var team in teams)
            {
                team.LotteryGamesBack = topGamesBehind - team.GamesBack;
                var teamWinLossDifference = team.Losses - team.Wins;

               team.LotteryGamesBack = (leadingLotteryTeamWinLossDifference - teamWinLossDifference) / 2;
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

        public static void SetPickNumberFromLotteryNumber(List<Team> teams)
        {
             foreach (var team in teams)
            {
                team.PickNumber = team.LotteryNumber;
            }
}

    }

     
}
