using System.Configuration;
using System.Web;

namespace FileCms.Models
{
    public class UrlPropertyModel
    {
        private readonly string _url = string.Empty;

        public UrlPropertyModel(string url)
        {
            _url = url;
        }

        public string RelativePath
        {
            get
            {
                var returnValue = _url;

                if (!returnValue.StartsWith("/")) returnValue = string.Format("/{0}", returnValue);
                if (!returnValue.EndsWith("/")) returnValue = string.Format("{0}/", returnValue);
                return returnValue;
            }
        }

        public string AbsolutePath
        {
            get
            {
                return HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }

        public string PhysicalPath
        {
            get
            {
                var contentPath = ConfigurationManager.AppSettings["ContentPath"];
                return HttpContext.Current.Server.MapPath(string.Format("{0}{1}", contentPath, RelativePath));
            }
        }
    }
}