using LotterySim.Business.Common;
using System;

namespace LotterySim.Business.NBA
{
	public class NBATeam : LotteryTeam
	{
		public string TopFourPickOdds { get; set; }
		public string TopPickOdds { get; set; }
		public int TieBreakerGroupPosition { get; set; }
		public double LotteryGamesBack { get; set; }
		public int TeamID { get; set; }
		public string TeamNickName { get; set; }
		public int PickNumber { get; set; }
		public string WinLossRecord { get; set; }
		public int ConferenceRank { get; set; }
		public string WinLossStreak { get; set; }
		public int ConsecutiveWinLoss { get; set; }
		public bool WinorLossStreak { get; set; }
		public int LastTenWins { get; set; }
		public int LastTenLosses { get; set; }
		public string LastTenGamesRecord { get; set; }

		public void SetLastTenWinLoss()
		{
			string[] lastTenWinLoss = this.LastTenGamesRecord.Split('-');
			this.LastTenWins = Convert.ToInt32(lastTenWinLoss[0]);
			this.LastTenLosses = Convert.ToInt32(lastTenWinLoss[1]);
		}
	}
}
