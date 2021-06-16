using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LotterySimPresentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
            routes.MapRoute(
               name: "Lottery",
               url: "",
               new { controller = "Lottery", action = "Index" }
               //new { controller = "Home", action = "GenerateLottery" }
               );
            */
            

            /*
            routes.MapRoute(
              name: "Lottery2",
              url: "",
              //new { controller = "Lottery", action = "Index" }
              new { controller = "Home", action = "GenerateLottery" }
              );
            */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}
