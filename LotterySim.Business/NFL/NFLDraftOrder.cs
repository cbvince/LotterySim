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
