using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileCms.Models
{
    public abstract class PageBaseModel
    {
        public LayoutModel Layout { get; set; }
        public UrlPropertyModel Url { get; set; }
    }
}