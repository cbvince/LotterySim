using LotterySim.Business.NBA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public interface IDraftPick
	{
		int PickNumber { get; set; }
		int RoundNumber { get; set; }
		PickSwapType PickSwapType { get; set; }
		ITeam Team { get; set; }
		ITeam TeamPickOwedTo { get; set; }
	}
}
