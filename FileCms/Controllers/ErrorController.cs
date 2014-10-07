using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileCms.Business.ModelBuilders;
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

        public ActionResult NotFound(string url, string folderPath)
        {
            var contentPath = ConfigurationManager.AppSettings["ContentPath"];
            var configPath = string.Format("{0}\\config.xml", folderPath);
            var config = new PageConfigModelBuilder().Build(configPath);
            var pagePathWithVpp = string.Format("{0}/ErrorPage/", contentPath, url);

            Response.StatusCode = 404;
            return View(new ErrorModel
                {
                    Url = new UrlPropertyModel(url),
                    Layout = new LayoutModel
                    {
                        HeaderImage = string.Format("{0}{1}", pagePathWithVpp, config.Header),
                        Title = config.Title,
                        MenuItems = new MenuModelBuilder().Create(contentPath)
                    }
                });
        }
    }
}
