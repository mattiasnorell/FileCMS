using FileCms.Controllers;

namespace FileCms.Models
{
    public class LayoutModel
    {
        public string Title { get; set; }
        public string HeaderImage { get; set; }
        public CustomFile[] CustomCss { get; set; }
        public CustomFile[] CustomScripts { get; set; } 
    }
}