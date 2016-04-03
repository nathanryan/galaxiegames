using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GalaxieGames
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "NewComment",
                 url: "comments/new",
                defaults: new { controller = "VideoGames", action = "AddComment" }
            );

            routes.MapRoute(
                name: "Comments",
                url: "comments",
                defaults: new { controller = "VideoGames", action = "Comments" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
