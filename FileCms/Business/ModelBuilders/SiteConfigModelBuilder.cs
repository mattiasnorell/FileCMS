using FileCms.Business.Cache;
using FileCms.Models;
using System.IO;
using System.Xml.Serialization;

namespace FileCms.Business.ModelBuilders
{
    public class SiteConfigModelBuilder
    {
        public SiteConfig Create(string configPath)
        {
            if (!File.Exists(configPath))
            {
                return new SiteConfig();
            }

            var cacheManager = new CacheHandler();
            var config = cacheManager.Get<SiteConfig>("siteConfig");

            if (config != null)
            {
                return config;
            }

            var xRoot = new XmlRootAttribute {ElementName = "site", IsNullable = true};
            var serializer = new XmlSerializer(typeof (SiteConfig), xRoot);
            var reader = new StreamReader(configPath);
                
            config = (SiteConfig) serializer.Deserialize(reader);
            reader.Close();

            cacheManager.Add("siteConfig", config);
            
            return config;
        }
    }
}