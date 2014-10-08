using System.Web;
using System.Web.Caching;

namespace FileCms.Business.Cache
{
    public class CacheHandler
    {
        public T Get<T>(string cacheName) where T : class
        {
            return HttpRuntime.Cache.Get(cacheName) as T;
        }

        public void Add(string cacheName, object cacheItem)
        {
            HttpContext.Current.Cache.Add(
                        cacheName,
                        cacheItem,
                        null,
                        System.Web.Caching.Cache.NoAbsoluteExpiration,
                        System.Web.Caching.Cache.NoSlidingExpiration,
                        CacheItemPriority.Normal,
                        null);
        }
    }
}