﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public abstract class Lottery : Team
	{
		public int LotteryNumber { get; set; }
		public string LotteryMovement { get; set; }
		public bool Assigned { get; set; }

		public Lottery()
		{

		}
	}
}
