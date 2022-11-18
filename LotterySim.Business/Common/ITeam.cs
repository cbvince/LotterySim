using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public interface ITeam
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
		public double WinPercentage { get; set; }
		public double GamesBack { get; set; }
		public string ImageUrl { get; set; }
		public int StandingsRank { get; set; }

		List<Team> GetTeams();
		void OrderTeams(List<ITeam> teams);
		void ProcessPickSwaps(List<ITeam> teams);
	}
}
