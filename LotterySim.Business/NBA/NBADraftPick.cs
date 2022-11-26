using LotterySim.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace LotterySim.Business.NBA
{
	public class NBADraftPick : IDraftPick
	{

		public int PickNumber { get; set; }
		public int RoundNumber { get; set; }
		public PickSwapType PickSwapType { get; set; }
		public int LotteryMovement { get; set; }
		public ITeam Team { get; set; }
		public ITeam TeamPickOwedTo { get; set; }

	}
}

