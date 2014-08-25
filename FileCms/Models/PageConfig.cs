using System;
using System.Xml.Serialization;

namespace FileCms.Models
{
    [Serializable()]
    [XmlRoot("Config")]
    public class PageConfig
    {
        public string Title { get; set; }
        public string Header { get; set; }

        [XmlArray("CustomCss")]
        [XmlArrayItem("File", typeof(CustomFile))]
        public CustomFile[] CustomCss { get; set; }

        [XmlArray("CustomScripts")]
        [XmlArrayItem("File", typeof(CustomFile))]
        public CustomFile[] CustomScripts { get; set; }
    }
}