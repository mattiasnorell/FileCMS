using System.Collections.Generic;
using System.Xml.Serialization;

namespace FileCms.Business.RedirectManager
{
    public class RedirectItems
    {
        [XmlElement("redirect")]
        public List<RedirectItem> Redirects { get; set; }
    }
}