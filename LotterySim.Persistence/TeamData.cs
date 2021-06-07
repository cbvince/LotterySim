using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Persistence
{
    public class TeamData
    {
        public class league
        {
            public stnd standard { get; set; }
            public class stnd
            {
                public List<Team> teams { get; set; }
                public class Team
                {
                    public int win { get; set; }
                    public int loss { get; set; }
                }
            }
        }
    }
}
