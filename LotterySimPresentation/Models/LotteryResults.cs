using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LotterySim.Business;
using LotterySim.Business.NBA;

namespace LotterySim.Models
{
    public class LotteryResults
    {
        public static List<NBATeam> GetLotteryTeams()
        {
            return GetNBATeams.GetLotteryTeams();
        }
    }
}