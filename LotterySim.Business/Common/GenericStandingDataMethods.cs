using LotterySim.Business.NFL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
    class GenericStandingDataMethods
    {
        public static int GetGamesBack(int highestNumberOfLosses, int lowestNumberOfWins, int teamWinLossDifference)
        {
            var winLostDifferenceForWorstTeam = highestNumberOfLosses - lowestNumberOfWins;
            var gamesBack = (winLostDifferenceForWorstTeam - teamWinLossDifference) / 2;
            return gamesBack;
        }

      
    }
}
