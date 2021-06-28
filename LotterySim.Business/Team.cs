using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business
{
    public class Team
    {

        Random random = new Random();

        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamNickName { get; set; }
        public int PickNumber { get; set; }
        public int TeamRank { get; set; }
        public int LotteryNumber { get; set; }
        public string LotteryMovement { get; set; }
        public string OriginalTeamName { get; set; }
        public string NewTeamName { get; set; }
        public string TeamPickOwedToName { get; set; }
        public string PickTradeDetails { get; set; }
        public PickSwapType PickSwapType { get; set; }
        public bool Assigned { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string WinLossRecord { get; set; }
        public int ConferenceRank { get; set; }
        public double WinPercentage { get; set; }
        public double GamesBack { get; set; }
        public double LotteryGamesBack { get; set; }
        public string WinLossStreak { get; set; }
        public int ConsecutiveWinLoss { get; set; }
        public bool WinorLossStreak { get; set; }
        public int LastTenWins { get; set; }
        public int LastTenLosses { get; set; }
        public string LastTenGamesRecord { get; set; }
        public string TopFourPickOdds { get; set; }
        public string TopPickOdds { get; set; }
        public int TieBreakerGroupPosition { get; set; }


    }

    public enum PickSwapType
    {
        None,
        Swapped,
        Protected

    }
}
