using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LotterySim.Business;

namespace LotterySimPresentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home


        
        public ActionResult Index()
        {
            var lotteryTeams = GetTeams.GetLotteryTeams();
            return View(lotteryTeams);
        }

        public ActionResult GenerateLottery()
        {
            var lotteryTeams = GetTeams.GetLotteryTeams();
            Lottery.RunLottery(lotteryTeams);
            //return View(lotteryTeams);
            return View("Index", lotteryTeams);
        
        }


        public ActionResult TeamDetail(string teamname)
        {

            if (teamname == null)
            {
                return View("Index", GetTeams.GetLotteryTeams());
            }

            var teams = GetTeams.GetLotteryTeams();
            var team = teams.FirstOrDefault(p => p.OriginalTeamName == teamname);
            return View(team);
        }
    }
}