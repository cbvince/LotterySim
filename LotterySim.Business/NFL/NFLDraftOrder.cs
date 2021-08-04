using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NFL
{
    class NFLDraftOrder
    {
       
        public static List<NFLTeam.Entry> GetNonPlayOffTeams(List<NFLTeam.Entry> teams)
        {
            return GetNFLTeamDraftGroup(teams, 12, 32);
        }

        public static List<NFLTeam.Entry> GetWildCardRoundLoserTeams(List<NFLTeam.Entry> teams)
        {
            return GetNFLTeamDraftGroup(teams, 6, 12);
        }

        public static List<NFLTeam.Entry> GetDivisionRoundLoserTeams(List<NFLTeam.Entry> teams)
        {
            return GetNFLTeamDraftGroup(teams, 4, 6);
        }

        //don't think this is needed - can get to team from entry
        private static List<NFLTeam.Team> GetTeamsFromEntries(List<NFLTeam.Entry> entries)
        {
            var teams = new List<NFLTeam.Team>;
           foreach (var entry in entries)
	        {
                teams.Add(entry.team);
	        }

           return teams;
        }

        private static List<NFLTeam.Entry> GetEntriesFromStandings(List<NFLTeam.Standings> standings)
        {
            
            var entries = new List<NFLTeam.Entry>;
            foreach (var standing in standings)
	        {
                entries.Add(standing.entries);
	        }
            return entries;
        }

        private static List<NFLTeam.Standings> GetStandingsFromChildren(List<NFLTeam.Child> children)

        {
            var overallStandings = new List<NFLTeam.Standings>;

            foreach (var child in children)
	        {
                overallStandings.AddRange(child.standings)
	        }
            
            return overallStandings;
        }
     




        private static List<NFLTeam.Entry> GetNFLTeamDraftGroup(List<NFLTeam.Entry> teams, int lowerSeedThreshold, int upperSeedThreshold)
        {
            var teamsDraftGroup = new List<NFLTeam.Entry>();
            foreach (var team in teams.Where(p => GetTeamPlayoffSeed(p.stats) > lowerSeedThreshold && GetTeamPlayoffSeed(p.stats) <= upperSeedThreshold))
            {
                teamsDraftGroup.Add(team);
            }

            return teamsDraftGroup;
        }



       

        private static int GetTeamPlayoffSeed(List<NFLTeam.Stat> stats)
        {
            var playoffSeed = stats.Where(p => p.name == "playoffSeed").FirstOrDefault().value;
            return playoffSeed;
        }

    }
}
