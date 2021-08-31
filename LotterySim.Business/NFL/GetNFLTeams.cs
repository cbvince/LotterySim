using LotterySim.Business.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NFL
{
    public class GetNFLTeams
    {
        private static NFLTeam.Rootobject GenerateNFLTeamStandings()
        {

            string endPoint = "https://site.api.espn.com/apis/v2/sports/football/nfl/standings";
            string strJSON = GetTeamDataFromWeb.GetTeamDataFromCache(1440, endPoint, "nfl");
            var teamData = JsonConvert.DeserializeObject<NFLTeam.Rootobject>(strJSON);
            return teamData;

        }

        private static List<NFLTeam.Standings> GetStandingsFromChildren()
        {


            var children = new List<NFLTeam.Child>();
            var standings = new List<NFLTeam.Standings>();

            children.Add(GenerateNFLTeamStandings().children[0]);
            children.Add(GenerateNFLTeamStandings().children[1]);

            foreach (var child in children)
            {
                standings.Add(child.standings);

            }

            return standings;
        }

        public static List<NFLTeam.Entry> GetEntriesFromStandings()
        {
            var entries = new List<NFLTeam.Entry>();

            foreach (var standing in GetStandingsFromChildren())
            {
                entries.AddRange(standing.entries);
            }
            SetNonPlayOffTeamDraftOrder(entries);
            SetPlayOffTeamDraftOrder(entries);
            SetGamesBack(entries);

            return entries;
        }



        private static void SetPlayOffTeamDraftOrder(List<NFLTeam.Entry> entries)
        {
            var i = 19;
            foreach (var entry in entries.Where(p => p.stats[0].value <= 7).OrderByDescending(p => p.stats[0].value).ThenBy(p => p.stats[1].value))
            {
                entry.DraftPick = i++;
            }
        }

        private static void SetNonPlayOffTeamDraftOrder(List<NFLTeam.Entry> entries)
        {
            var i = 1;
            foreach (var entry in entries.Where(p => p.stats[0].value > 7).OrderByDescending(p => p.stats[2].value).ThenBy(p => p.stats[1].value))
            {
                entry.DraftPick = i++;
            }
        }



        public static List<NFLTeam.Entry> GetNFLTeamDraftGroup(List<NFLTeam.Entry> teams, int lowerSeedThreshold, int upperSeedThreshold)
        {
            var teamsDraftGroup = new List<NFLTeam.Entry>();

            foreach (var team in teams.Where(p => p.DraftPick > lowerSeedThreshold && p.DraftPick <= upperSeedThreshold))
            {

                teamsDraftGroup.Add(team);
                teamsDraftGroup.OrderBy(p => p.DraftPick);
            }

            return teamsDraftGroup;
        }

        private static void SetGamesBack(List<NFLTeam.Entry> teams)
        {

            var teamHighestLosses = teams.OrderByDescending(p => p.stats[2].value).FirstOrDefault().stats[2].value;
            var teamLowestWins = teams.OrderBy(p => p.stats[1].value).FirstOrDefault().stats[1].value;


            foreach (var team in teams)
            {
                var teamWinLossDifference = team.stats[2].value - team.stats[1].value;

                team.stats[4].value = GenericStandingDataMethods.GetGamesBack((int)teamHighestLosses, (int)teamLowestWins, (int)teamWinLossDifference);
            }

        }
    }
}
