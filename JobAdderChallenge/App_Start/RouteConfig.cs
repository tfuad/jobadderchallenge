using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JobAdderChallenge
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Routing will be handled by Angular for this project.
            routes.MapRoute(
                name: "Default",
                url: "{*.}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
