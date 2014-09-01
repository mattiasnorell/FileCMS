using System.Collections.Generic;
using System.Web.Mvc;

namespace FileCms.Models
{
    public class PageContentModel: PageBaseModel
    {
        public MvcHtmlString Content { get; set; }
        public string Header { get; set; }
        public List<string> CustomCss { get; set; }
        public List<string> CustomScripts { get; set; } 
    }
}