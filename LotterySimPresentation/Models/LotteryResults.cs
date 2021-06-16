using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LotterySim.Business;

namespace LotterySim.Models
{
    public class LotteryResults
    {
        public static List<Team> GetLotteryTeams()
        {
            return GetTeams.GetLotteryTeams();
        }
    }
}