using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public interface ITeam
	{
		string TeamName { get; set; }
		string OriginalTeamName { get; set; }
		string NewTeamName { get; set; }
		string TeamPickOwedToName { get; set; }
		ITeam TeamPickOwedTo { get; set; }
		string PickTradeDetails { get; set; }
		PickSwapType PickSwapType { get; set; }
		int Wins { get; set; }
		int Losses { get; set; }
		public string WinLossRecord { get; set; }
		string Streak { get; set; }
		decimal WinPercentage { get; set; }
		double GamesBack { get; set; }
		public double InverseGamesBack { get; set; }
		string ImageUrl { get; set; }
		int TeamRank { get; set; }
	}
}
