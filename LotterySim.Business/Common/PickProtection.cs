using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public class PickProtection
	{
		public string FromTeam { get; set; }
		public string ToTeam { get; set; }
		public int LowerPickProtectionThreshold { get; set; }
		public int UpperPickProtectionThreshold { get; set; }
	}
}
