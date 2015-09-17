using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FileCms
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var adminPath = ConfigurationManager.AppSettings["AdminPath"];

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute( "Admin", adminPath + "/{controller}/{action}/{id}", new {controller = "Administration", action = "Index", id = ""});

            routes.MapRoute(
            name: "Default",
            url: "{*FriendlyUrl}").RouteHandler = new FriendlyUrlRouteHandler();
        }
    }
}