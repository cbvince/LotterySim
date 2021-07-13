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

            try
            {
                var lotteryTeams = GetNBATeams.GetLotteryTeams();
                return View(lotteryTeams);
            }
            catch (Exception ex)
            {
               

                return View("Error", new HandleErrorInfo(ex, "Index", "Home"));
            }

            
        }

        public ActionResult GenerateLottery()
        {
            try
            {
                var lotteryTeams = GetNBATeams.GetLotteryTeams();
                Lottery.RunLottery(lotteryTeams);
                return View("Index", lotteryTeams);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Index", "Home"));
            }
            
          
        
        }


        public ActionResult TeamDetail(string teamname)
        {

            if (teamname == null)
            {
                return View("Index", GetNBATeams.GetLotteryTeams());
            }

            var teams = GetNBATeams.GetLotteryTeams();
            var team = teams.FirstOrDefault(p => p.OriginalTeamName == teamname);
            return View(team);
        }
    }
}