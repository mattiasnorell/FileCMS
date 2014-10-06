using System.Xml.Serialization;

namespace FileCms.Business.RedirectManager
{
    public class RedirectItem
    {
        [XmlElement("to")]
        public string To { get; set; }

        [XmlElement("from")]
        public string From { get; set; }
    }
}