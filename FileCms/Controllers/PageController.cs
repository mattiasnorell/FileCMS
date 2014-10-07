using System.Configuration;
using FileCms.Business.ModelBuilders;
using FileCms.Models;
using System;
using System.Web.Mvc;

namespace FileCms.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index(string url, string folderPath)
        {
            var templatePath = string.Format("{0}page.html", folderPath);
            var configPath = string.Format("{0}config.xml", folderPath);
            var contentPath = ConfigurationManager.AppSettings["ContentPath"];
            var pagePathWithVpp = string.Format("{0}/Pages/{1}", contentPath, url);

            if (!System.IO.File.Exists(templatePath))
            {
                throw new Exception("Page template not found.");
            }

            var pageUrl = new UrlPropertyModel(url);
            var config = new PageConfigModelBuilder().Build(configPath);
            var templateContent = System.IO.File.ReadAllText(templatePath);
            var pageContent = new MvcHtmlString(templateContent.Replace("{PAGE_PATH}", pagePathWithVpp));

            return View(new PageContentModel
                {
                    Content = pageContent,
                    Url = pageUrl,
                    Layout = new LayoutModel
                        {
                            HeaderImage = string.Format("{0}{1}", pagePathWithVpp, config.Header),
                            Title = config.Title,
                            CustomCss = config.CustomCss,
                            CustomScripts = config.CustomScripts,
                            MenuItems = new MenuModelBuilder().Create(contentPath),
                            SiteConfig = new SiteConfigModelBuilder().Create(Server.MapPath(string.Format("{0}/SiteConfig.xml", contentPath)))
                        }
                });
        }
    }
}