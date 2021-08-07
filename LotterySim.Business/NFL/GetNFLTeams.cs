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
                entries.OrderBy(p=> Get)
            }
            return entries;
        }

        
        

        


        public static int GetStatByName(NFLTeam.Stat[] stats, string statName)

        {
            var statsList = new List<NFLTeam.Stat>();
            statsList.AddRange(stats);
            return (int)statsList.FirstOrDefault(p => p.name == statName).value;
        }


        private static List<NFLTeam.Entry> GetNFLTeamDraftGroup(List<NFLTeam.Entry> teams, int lowerSeedThreshold, int upperSeedThreshold)
        {
            var teamsDraftGroup = new List<NFLTeam.Entry>();
            
            foreach (var team in teams.Where(p => GetStatByName(p.stats, "playoffSeed") > lowerSeedThreshold && GetStatByName(p.stats, "playoffSeed") <= upperSeedThreshold))
            {

                teamsDraftGroup.Add(team);
            }

            return teamsDraftGroup;
        }

    }
}

