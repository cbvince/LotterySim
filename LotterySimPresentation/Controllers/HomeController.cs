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

        /*
        [HttpPost]
        public ActionResult Index(List<Team> lotteryteams)
        {
            //var lotteryTeams = GetTeams.GetLotteryTeams();
            Lottery.RunLottery(lotteryteams);
            return View(lotteryteams);
        }
        */


        public ActionResult GenerateLottery()
        {
            var lotteryTeams = GetTeams.GetLotteryTeams();
            Lottery.RunLottery(lotteryTeams);
            return View(lotteryTeams);
        }
    }
}