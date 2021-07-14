using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NFL
{
    class NFLDraftOrder
    {
       private static void GetNonPlayoffTeams(List<NFLTeam> teams)
        {
        }


        private static void GetPlayoffTeams(List<NFLTeam> teams)
        {
        }

        private static List<NFLTeam.Entry> GetAFCTeams(List<NFLTeam.Entry> teams)
        {
            var afcTeams = new List<NFLTeam.Entry>();

            foreach (var team in teams)
            {
                afcTeams.Add(team);
                var teamStats = team.stats;
                bool playoffTeam = teamStats.Exists(p => p.displayName == "playoffSeed" && p.value < 8);
            }

            return afcTeams;
        }

    }
}
