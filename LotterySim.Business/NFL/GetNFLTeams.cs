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
            GenerateNFLDraftOrder(entries); 
            return entries;
        }

    
        private static void GenerateNFLDraftOrder(List<NFLTeam.Entry> entries)
        {
            var i = 1;
            var orderedEntries = entries.OrderByDescending(p => GetStatByName(p.stats, "playoffSeed")).ThenBy(p => (GetStatByName(p.stats, "wins")));

            foreach (var entry in orderedEntries)
            {
                entry.DraftPick = i++;
            }

            orderedEntries.OrderBy(p => p.DraftPick);
        }

        
        

        


        public static float GetStatByName(NFLTeam.Stat[] stats, string statName)

        {
            var statsList = new List<NFLTeam.Stat>();
            statsList.AddRange(stats);
            return statsList.FirstOrDefault(p => p.name == statName).value;
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
        
    }
}

