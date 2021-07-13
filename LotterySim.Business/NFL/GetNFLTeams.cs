using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NFL
{
    class GetNFLTeams
    {
        private static List<NFLTeam> GenerateNFLTeamStandings()
        {

            string endPoint = "https://site.api.espn.com/apis/v2/sports/football/nfl/standings";
            string strJSON = GetTeamDataFromWeb.GetTeamDataFromCache(1440, endPoint);
            var teamdata = JsonConvert.DeserializeObject<dynamic>(strJSON);



            var teams = new List<NFLTeam>();

            {
                var i = 1;
                foreach (var team in teamdata.league.standard.teams)
                {
                    string teamName = team.teamSitesOnly.teamName;

                    teams.Add(new NFLTeam()
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
                        TeamRank = i++

                    });

                }

            };


            return teams;
        }
    }
}

