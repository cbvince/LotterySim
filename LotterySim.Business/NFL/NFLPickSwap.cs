using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NFL
{
    class NFLPickSwap
    {

        private static void SwapNFLPicks(List<NFLTeam.NFLDraftPick> picks, string fromTeamName, string toTeamName, int roundNumber)
        {
            
            var entries = GetNFLTeams.GetEntriesFromStandings();
            var fromEntry = entries.Where(p => p.team.displayName == fromTeamName).FirstOrDefault();
            var toEntry = entries.Where(p => p.team.displayName == toTeamName).FirstOrDefault();
            //var pickToUpdate = picks.Where(p => p.DraftRound == roundNumber && p.Team == fromEntry).FirstOrDefault();
            //var pickToUpdate = picks.Where(p => p.DraftRound == roundNumber).FirstOrDefault();
            //var pickToUpdate = picks.Where(p => p.Team == fromEntry).FirstOrDefault();
            var pickToUpdate = picks.Where(p => p.DraftRound == roundNumber && p.Team.team.displayName == fromTeamName).FirstOrDefault();

            pickToUpdate.Team = toEntry;
            pickToUpdate.OriginalTeam = fromEntry;
            pickToUpdate.PickSwapType = PickSwapType.Swapped;
        }

        public static void NFLSeasonPickSwaps(List<NFLTeam.NFLDraftPick> picks)
        {
            SwapNFLPicks(picks, "Chicago Bears", "New York Giants", 1);
            SwapNFLPicks(picks, "Indianapolis Colts", "Philadelphia Eagles", 1);
            SwapNFLPicks(picks, "Miami Dolphins", "Philadelphia Eagles", 1);
            SwapNFLPicks(picks, "Seattle Seahawks", "New York Jets", 1);
            SwapNFLPicks(picks, "San Francisco 49ers", "Miami Dolphins", 1);
            SwapNFLPicks(picks, "Los Angeles Rams", "Detroit Lions", 1);


        }


    }
}
