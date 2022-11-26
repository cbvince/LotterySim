using LotterySim.Business.Common;
using System;

namespace LotterySim.Business.NBA
{
	public class NBATeam : ILotteryTeam, ITeam
	{
		public string TopFourPickOdds { get; set; }
		public string TopPickOdds { get; set; }
		public int TieBreakerGroupPosition { get; set; }
		public double InverseGamesBack { get; set; }
		public int TeamID { get; set; }
		public string TeamNickName { get; set; }
		public int PickNumber { get; set; }
		public string WinLossRecord { get; set; }
		public int ConferenceRank { get; set; }
		public string WinLossStreak { get; set; }
		public int ConsecutiveWinLoss { get; set; }
		public int LastTenWins { get; set; }
		public int LastTenLosses { get; set; }
		public string LastTenGamesRecord { get; set; }
		public string TeamName { get; set; }
		public string OriginalTeamName { get; set; }
		public string NewTeamName { get; set; }
		public string TeamPickOwedToName { get; set; }
		public ITeam TeamPickOwedTo { get; set; }
		public string PickTradeDetails { get; set; }
		public PickSwapType PickSwapType { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }
		public string Streak { get; set; }
		public decimal WinPercentage { get; set; }
		public double GamesBack { get; set; }
		public string ImageUrl { get; set; }
		public int TeamRank { get; set; }
		public int LotteryNumber { get; set; }
		public string LotteryMovement { get; set; }
		public bool Assigned { get; set; }

		public void SetLastTenWinLoss()
		{
			string[] lastTenWinLoss = this.LastTenGamesRecord.Split('-');
			this.LastTenWins = Convert.ToInt32(lastTenWinLoss[0]);
			this.LastTenLosses = Convert.ToInt32(lastTenWinLoss[1]);
		}
	}
}
