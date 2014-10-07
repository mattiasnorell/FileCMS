using FileCms.Business.Cache;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FileCms.Business.RedirectManager
{
    public class RedirectManager
    {
        public RedirectItems Get()
        {

            var cacheManager = new CacheHandler();
            var redirectCache = cacheManager.Get<RedirectItems>("redirectItems");

            if (redirectCache != null)
            {
                return redirectCache;
            }

            var root = ConfigurationManager.AppSettings["ContentPath"];
            var reader = new StreamReader(HttpContext.Current.Server.MapPath(root + "/redirects.xml"));
            var xRoot = new XmlRootAttribute {ElementName = "redirects", IsNullable = true};
            var serializer = new XmlSerializer(typeof(RedirectItems), xRoot);
            var redirects = (RedirectItems)serializer.Deserialize(reader);
            reader.Close();

            cacheManager.Add("redirectItems", redirects);

            return redirects;
        }

        public string CheckRedirect(string from)
        {

            var redirects = Get();

            if (redirects.Redirects == null || !redirects.Redirects.Any()) return null;
            if (!from.StartsWith("/")){
                from = string.Format("/{0}", from);
            }

            var redirect = redirects.Redirects.FirstOrDefault(e => e.From == from);

            return (redirect == null) ? null : redirect.To;
        }
    }
}