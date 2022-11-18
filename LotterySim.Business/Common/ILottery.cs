using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public interface ILottery
	{
		public int LotteryNumber { get; set; }
		public string LotteryMovement { get; set; }
		public bool Assigned { get; set; }

		void RunLottery();
	}

	
}
