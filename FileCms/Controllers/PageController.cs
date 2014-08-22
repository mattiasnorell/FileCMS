using System.Configuration;
using FileCms.Models;
using System.Web.Mvc;

namespace FileCms.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index(string path, string template)
        {
            
            var text = System.IO.File.Exists(template) ? System.IO.File.ReadAllText(template) : "";

            return View(new PageContentModel
                {
                    Content = text,
                    Layout = new LayoutModel
                        {
                            HeaderImage = string.Format("{0}/{1}header.jpg", ConfigurationManager.AppSettings["ContentPath"], path)
                        }
                });
        }
    }
}