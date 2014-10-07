using System;
using System.Configuration;
using System.Xml.Serialization;

namespace FileCms.Models
{
    [Serializable()]
    [XmlRoot("Config")]
    public class PageConfig
    {
        private string _header = string.Empty;
        private string _contentPath = ConfigurationManager.AppSettings["ContentPath"];

        public string ConfigPath { get; set; }
        public string Title { get; set; }
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        [XmlArray("CustomCss")]
        [XmlArrayItem("File", typeof(CustomFile))]
        public CustomFile[] CustomCss { get; set; }

        [XmlArray("CustomScripts")]
        [XmlArrayItem("File", typeof(CustomFile))]
        public CustomFile[] CustomScripts { get; set; }
    }
}