﻿using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace FileCms
{
    public class FriendlyUrlRouteHandler : System.Web.Mvc.MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            var friendlyUrl = "/";
            var contentPath = ConfigurationManager.AppSettings["ContentPath"] ?? "/";

            if(!string.IsNullOrEmpty((string)requestContext.RouteData.Values["FriendlyUrl"]))
            {
                friendlyUrl = (string)requestContext.RouteData.Values["FriendlyUrl"];
            };

            var folderPath = HttpContext.Current.Server.MapPath(string.Format("{0}/{1}", contentPath, friendlyUrl));

            if (!friendlyUrl.EndsWith("/"))
            {
                friendlyUrl = string.Format("/{0}/", friendlyUrl);
                requestContext.HttpContext.Response.Status = "301 Moved Permanently";
                requestContext.HttpContext.Response.StatusCode = 301;
                requestContext.HttpContext.Response.RedirectPermanent(friendlyUrl);
                return base.GetHttpHandler(requestContext);
            }

            if (!Directory.Exists(folderPath))
            {
                requestContext.RouteData.Values["controller"] = "Error";
                requestContext.RouteData.Values["action"] = "NotFound";
                requestContext.RouteData.Values["url"] = friendlyUrl;
            }
            else
            {
                requestContext.RouteData.Values["controller"] = "Page";
                requestContext.RouteData.Values["action"] = "Index";
                requestContext.RouteData.Values["path"] = friendlyUrl;
                requestContext.RouteData.Values["template"] = string.Format("{0}page.html", folderPath);
            }

            return base.GetHttpHandler(requestContext);
        }
    }
}