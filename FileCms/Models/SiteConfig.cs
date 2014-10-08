using System.Xml.Serialization;

namespace FileCms.Models
{
    public class SiteConfig
    {
        [XmlElement("analytics")]
        public AnalyticsConfig Analytics { get; set; }

        [XmlElement("disqus")]
        public DisqusConfig Disqus { get; set; }
    }

    public class DisqusConfig
    {
        [XmlElement("account")]
        public string Account { get; set; }
    }

    public class AnalyticsConfig
    {
        [XmlElement("enable")]
        public bool Enable { get; set; }
        [XmlElement("account")]
        public string Account { get; set; }
    }
}