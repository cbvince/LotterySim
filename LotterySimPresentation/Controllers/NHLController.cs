using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LotterySim.Business.NHL;

namespace LotterySimPresentation.Controllers
{
    public class NHLController : Controller
    {
        // GET: NHL
        public ActionResult NHLStandings()
        {
            try
            {
                var defaultPicks = SetNHLDraftOrder.NHLDefaultDraftPicksFromCache();
                return View("NHLStandings", defaultPicks);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "NHLStandings", "NHL"));
            }
        }


        public ActionResult NHLTeamDetail(string teamID)
        {
            if (!string.IsNullOrEmpty(teamID))
            {
                try
                {
                    var teamPicks = SetNHLDraftOrder.NHLDefaultDraftPicksFromCache().Where(p => p.Team.team.id.ToString() == teamID);

                    return View(teamPicks);
                }
                catch (Exception ex)
                {

                    return View("Error", new HandleErrorInfo(ex, "NHLTeamDetail", "NHL"));
                }
            }

            else
            {
                return NHLStandings();
            }

        }

        }


    }
            