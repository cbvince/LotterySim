using LotterySim.Business.NFL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LotterySimPresentation.Controllers
{
    public class NFLController : Controller
    {
        // GET: NFL
        public ActionResult NFLStandings()
        {
            try
            {
                
                var nflTeamEntries = GetNFLTeams.GetEntriesFromStandings();
                return View("NFLStandings", nflTeamEntries);

            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "NFLStandings", "NFL"));
            }
        }
    }
}