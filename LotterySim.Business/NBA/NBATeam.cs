using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NBA
{
    public class NBATeam : Team
    {
        public int LotteryNumber { get; set; }
        public string LotteryMovement { get; set; }

        public string TopFourPickOdds { get; set; }
        public string TopPickOdds { get; set; }
        public int TieBreakerGroupPosition { get; set; }

        public double LotteryGamesBack { get; set; }
    }
}
