using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public abstract class Team
	{
		public string TeamName { get; set; }
		public string OriginalTeamName { get; set; }
		public string NewTeamName { get; set; }
		public string TeamPickOwedToName { get; set; }
		public string PickTradeDetails { get; set; }
		public PickSwapType PickSwapType { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }
		public int Ties { get; set; }
		public string Streak { get; set; }
		public decimal WinPercentage { get; set; }
		public double GamesBack { get; set; }
		public string ImageUrl { get; set; }
		public int TeamRank { get; set; }

	}
}
