using LotterySim.Business.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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

        public static List<NFLTeam.Entry> GetOrderedEntriesFromCache()
        {



            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains("orderedEntries"))
            {
                var orderedEntries = cache.GetCacheItem("orderedEntries").Value;
                return (List<NFLTeam.Entry>)orderedEntries;

            }

            else
            {
                cache.Add("orderedEntries", GetOrderedEntries(), DateTimeOffset.Now.AddMinutes(60));
                return GetOrderedEntriesFromCache();
            }


        }

        private static void SetGamesBack(List<NFLTeam.Entry> teams)
        {

            var teamHighestLosses = teams.OrderByDescending(p => p.stats[2].value).FirstOrDefault().stats[2].value;
            var teamLowestWins = teams.OrderBy(p => p.stats[1].value).FirstOrDefault().stats[1].value;


            foreach (var team in teams)
            {
                var teamWinLossDifference = team.stats[2].value - team.stats[1].value;

                //team.stats[4].value = GenericStandingDataMethods.GetGamesBack((int)teamHighestLosses, (int)teamLowestWins, (int)teamWinLossDifference);
            }

        }
    }
}


