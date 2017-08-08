using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                    new
                    {
                        controller = "Lot",
                        action = "Index",
                        category = (string)null,
                        page = 1
                    }
                );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Lot", action = "Index", category = (string)null, searchString = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Lot", action = "Index", page = 1 }
            );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Lot", action = "Index" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{searchString}/Page{page}",
                new { controller = "Lot", action = "Index" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}