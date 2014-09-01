using FileCms.Models;
using System.IO;
using System.Xml.Serialization;

namespace FileCms.Business.ModelBuilders
{
    public class PageConfigModelBuilder
    {
        public PageConfig Build(string configPath)
        {
            if (!File.Exists(configPath))
            {
                return new PageConfig();
            }

            var serializer = new XmlSerializer(typeof(PageConfig));
            var reader = new StreamReader(configPath);
            var config = (PageConfig)serializer.Deserialize(reader);
            reader.Close();

            return config;
        }
    }
}