using LotterySim.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LotterySimPresentation.Controllers
{
    public class LotteryController : Controller
    {
        // GET: Lottery
        public ActionResult Index()
        {
            var lotteryTeams = GetTeams.GetLotteryTeams();
            Lottery.RunLottery(lotteryTeams);
            return View(lotteryTeams);
           
        }
    }
}