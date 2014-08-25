using System.Collections.Generic;

namespace FileCms.Models
{
    public class PageContentModel: PageBaseModel
    {
        public string Content { get; set; }
        public string Header { get; set; }
        public List<string> CustomCss { get; set; }
        public List<string> CustomScripts { get; set; } 
    }
}