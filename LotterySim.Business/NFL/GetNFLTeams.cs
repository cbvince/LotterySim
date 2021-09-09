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


            SetGamesBack(entries);
            //SetRemainingRoundDraftOrder(entries);
            //List<NFLTeam.Entry> sortedEntries = entries.OrderBy(p => p.DraftPicks.FirstOrDefault().PickNumber).ToList();

            //return sortedEntries;
            return entries;
        }

        private static List<NFLTeam.Entry> GetOrderedEntries()
        {
            var orderedEntries = new List<NFLTeam.Entry>();
            var entries = GetEntriesFromStandings();

            orderedEntries.AddRange(entries.Where(p => p.stats[0].value > 7).OrderByDescending(p => p.stats[2].value).ThenBy(p => p.stats[1].value));
            orderedEntries.AddRange(entries.Where(p => p.stats[0].value <= 7).OrderByDescending(p => p.stats[0].value).ThenBy(p => p.stats[1].value));

            return orderedEntries;
        }

        private static List<NFLTeam.NFLDraftPick> GenerateDraftPicks()
        {

            var startingPick = 1;
            var entries = GetOrderedEntries();
            var draftPicks = new List<NFLTeam.NFLDraftPick>();

            foreach (var entry in entries)
            {
                draftPicks.Add(new NFLTeam.NFLDraftPick { DraftRound = 1, OriginalTeam = entry, Team = entry, PickNumber = startingPick++ });
                SetRemainingRoundDraftOrder(draftPicks, entry);
                
            }

            NFLPickSwap.NFLSeasonPickSwaps(draftPicks);
            return draftPicks;

        }

        private static void SetRemainingRoundDraftOrder(List<NFLTeam.NFLDraftPick> picks, NFLTeam.Entry entry)
        {

            var firstRoundPickNumber = picks.Where(p => p.DraftRound == 1 && p.Team == entry).FirstOrDefault().PickNumber;
            var i = 2;
            var currentPickNumber = firstRoundPickNumber + 32;

            while (i < 8)
            {
                picks.Add(new NFLTeam.NFLDraftPick() { DraftRound = i++, PickNumber = currentPickNumber, OriginalTeam = entry, Team = entry });
                currentPickNumber += 32;

            }




        }

        public static List<NFLTeam.NFLDraftPick> GetNFlDraftPicksByRound(int roundNumber)
        {

            var roundPicks = GenerateDraftPicks().Where(p => p.DraftRound == roundNumber).ToList();

            return roundPicks;

        }

        public static List<NFLTeam.NFLDraftPick> GetNFlDraftPicksByTeam(int teamID)
        {

            var picks = GenerateDraftPicks().Where(p => int.Parse(p.Team.team.id) == teamID).ToList();

            return picks;

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


