using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public class DraftPick : IDraftPick
	{
		public int PickNumber {get; set; }
		public int RoundNumber { get; set; }
		public PickSwapType PickSwapType { get; set; }
		public ITeam Team { get; set; }
		public ITeam TeamPickOwedTo { get; set; }

	}
}
