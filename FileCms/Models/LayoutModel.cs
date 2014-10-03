
using System.Collections.Generic;
using FileCms.Business.ModelBuilders;

namespace FileCms.Models
{
    public class LayoutModel
    {
        public string Title { get; set; }
        public string HeaderImage { get; set; }
        public CustomFile[] CustomCss { get; set; }
        public CustomFile[] CustomScripts { get; set; }
        public IEnumerable<MenuListItem> MenuItems { get; set; }
    }
}