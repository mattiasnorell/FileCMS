using FileCms.Models;
using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace FileCms.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index(string url, string pagePath)
        {
            var templatePath = string.Format("{0}page.html", pagePath);
            var configPath = string.Format("{0}config.xml", pagePath);

            if (!System.IO.File.Exists(configPath) && ConfigurationManager.AppSettings["UseDefaultSettingsIfMissing"] == "True" && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["DefaultSettingsPath"]))
            {
                configPath = Server.MapPath(ConfigurationManager.AppSettings["DefaultSettingsPath"]);
            }
            else if (!System.IO.File.Exists(configPath) && ConfigurationManager.AppSettings["UseDefaultSettingsIfMissing"] != "True")
            {
                throw new Exception("Page config not found.");
            }

            if (!System.IO.File.Exists(templatePath))
            {
                throw new Exception("Page template not found.");
            }

            var pageUrl = new UrlPropertyModel(url);
            var templateContent = System.IO.File.ReadAllText(templatePath);
            var serializer = new XmlSerializer(typeof(PageConfig));
            var reader = new StreamReader(configPath);
            var config = (PageConfig)serializer.Deserialize(reader);
            reader.Close();

            return View(new PageContentModel
                {
                    Content = templateContent,
                    Url = pageUrl,
                    Layout = new LayoutModel
                        {
                            HeaderImage = string.Format("{0}{1}", ConfigurationManager.AppSettings["ContentPath"], config.Header),
                            Title = config.Title,
                            CustomCss = config.CustomCss,
                            CustomScripts = config.CustomScripts
                        }
                });
        }
    }
}