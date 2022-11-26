using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public class LotteryDraftPick : IDraftPick
	{
		public int PickNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int RoundNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public PickSwapType PickSwapType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public ITeam Team { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public ITeam TeamPickOwedTo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
