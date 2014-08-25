using FileCms.Business.ModelBuilders;
using FileCms.Models;
using System;
using System.Web.Mvc;

namespace FileCms.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index(string url, string pagePath)
        {
            var templatePath = string.Format("{0}page.html", pagePath);
            var configPath = string.Format("{0}config.xml", pagePath);

            if (!System.IO.File.Exists(templatePath))
            {
                throw new Exception("Page template not found.");
            }

            var pageUrl = new UrlPropertyModel(url);
            var templateContent = System.IO.File.ReadAllText(templatePath);
            var config = new PageConfigModelBuilder().Build(configPath);

            return View(new PageContentModel
                {
                    Content = templateContent,
                    Url = pageUrl,
                    Layout = new LayoutModel
                        {
                            HeaderImage = config.Header,
                            Title = config.Title,
                            CustomCss = config.CustomCss,
                            CustomScripts = config.CustomScripts
                        }
                });
        }
    }
}