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
                var nflTeamPicks = GetNFLTeams.GetNFlDraftPicksByRound(round);
                return View("NFLStandings", nflTeamPicks);

            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "NFLStandings", "NFL"));
            }
        }


        public ActionResult NFLTeamDetail(int teamID)
        {

            

            var teams = GetNFLTeams.GetEntriesFromStandings();
            var team = teams.Where(p => int.Parse(p.team.id) == teamID).FirstOrDefault();

            if (team == null)
            {
                return View("NFLStandings", GetNFLTeams.GetNFlDraftPicksByRound(1));
            }

            else
            {
                return View(team);
            }


            
        }

    }
}