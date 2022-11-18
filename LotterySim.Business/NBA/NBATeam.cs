using LotterySim.Business.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NBA
{
	public class NBATeam : Team
	{
		public int LotteryNumber { get; set; }
		public string LotteryMovement { get; set; }
		public string TopFourPickOdds { get; set; }
		public string TopPickOdds { get; set; }
		public int TieBreakerGroupPosition { get; set; }
		public double LotteryGamesBack { get; set; }
		public int TeamID { get; set; }
		public string TeamNickName { get; set; }
		public int PickNumber { get; set; }
		public bool Assigned { get; set; }
		public string WinLossRecord { get; set; }
		public int ConferenceRank { get; set; }
		public string WinLossStreak { get; set; }
		public int ConsecutiveWinLoss { get; set; }
		public bool WinorLossStreak { get; set; }
		public int LastTenWins { get; set; }
		public int LastTenLosses { get; set; }
		public string LastTenGamesRecord { get; set; }



		private static void ProcessPickSwaps(List<ITeam> teams)
		{
			throw new NotImplementedException();
		}

		public void RunLottery()
		{
			throw new NotImplementedException();
		}
	}
}
