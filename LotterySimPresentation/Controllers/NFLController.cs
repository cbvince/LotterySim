using LotterySim.Business.NFL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace LotterySimPresentation.Controllers
{
    public class NFLController : Controller
    {
        // GET: NFL
        public ActionResult NFLStandings(int round = 1)
        {
            try
            {
                ViewData["Round"] = round;
                var nflTeamPicks = SetNFLDraftPicks.GetNFlDraftPicksByRound(round);
                return View("NFLStandings", nflTeamPicks);

            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "NFLStandings", "NFL"));
            }
        }


        public ActionResult NFLTeamDetail(int teamID = -1)
        {



            if (teamID != -1)
            {

                try
                {

                    return View(GetNFLTeams.GetNFlDraftPicksByTeam(teamID));

                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "NFLTeamDetail", "NFL"));

                }

            }

            else
            {

                return NFLStandings();
            }

        }

    }
}