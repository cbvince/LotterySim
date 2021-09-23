using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NHL
{
    public static class NHLPickSwap
    {
        private static void SwapNHLPicks(List<NHLDraftPick> picks, string fromTeamName, string toTeamName, int roundNumber)
        {

            var nhlTeams  = GetNHLTeams.GetOrderedTeams();
            var fromEntry = nhlTeams.Where(p => p.team.name == fromTeamName).FirstOrDefault();
            var toTeam = nhlTeams.Where(p => p.team.name == toTeamName).FirstOrDefault();

            var pickToUpdate = picks.Where(p => p.Team.team.name == fromTeamName).FirstOrDefault();

            pickToUpdate.Team = toTeam;
            pickToUpdate.OriginalTeam = fromEntry;
            pickToUpdate.PickSwapType = PickSwapType.Swapped;
        }

        public static void NHLSeasonPickSwaps(List<NHLDraftPick> picks)
        {

            SwapNHLPicks(picks, "Montréal Canadiens", "Arizona Coyotes", 1);
            SwapNHLPicks(picks, "Chicago Blackhawks", "Columbus Blue Jackets", 1);
            SwapNHLPicks(picks, "Florida Panthers", "Buffalo Sabres", 1);
            SwapNHLPicks(picks, "Carolina Hurricanes", "Montréal Canadiens", 1);
            SwapNHLPicks(picks, "Colorado Avalanche", "Arizona Coyotes", 1);

        }


    }

  
}
