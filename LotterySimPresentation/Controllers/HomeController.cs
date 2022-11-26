using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LotterySim.Business;
using LotterySim.Business.Common;
using LotterySim.Business.NBA;
using LotterySim.Business.NFL;

namespace LotterySimPresentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                List<IDraftPick> draftPicks = NBATeamStandings.GetDraftPicks();
                return View(draftPicks);
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
                var lotteryTeams = NBATeamStandings.GetTeams();
                //Lottery.RunLottery(lotteryTeams);
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
                return View("Index", NBATeamStandings.GetTeams());
            }

            var teams = NBATeamStandings.GetTeams();
            var team = teams.FirstOrDefault(p => p.OriginalTeamName == teamname);
            return View(team);
        }
    }
}