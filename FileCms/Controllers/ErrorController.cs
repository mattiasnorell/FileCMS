using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileCms.Models;

namespace FileCms.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Page/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound(string url)
        {
            Response.StatusCode = 404;
            return View(new ErrorModel
                {
                    Url = new UrlPropertyModel(url),
                    Layout = new LayoutModel
                    {
                        HeaderImage = "http://mrwgifs.com/wp-content/uploads/2013/03/James-Van-Der-Beek-Crying-On-Dawsons-Creek-Gif.gif",
                        Title = "Page not found"
                    }
                });
        }
    }
}
