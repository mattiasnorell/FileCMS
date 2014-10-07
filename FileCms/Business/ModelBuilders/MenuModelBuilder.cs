using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace FileCms.Business.ModelBuilders
{
    public class MenuModelBuilder
    {
        public IEnumerable<MenuListItem> Create(string contentPath)
        {
            
            var pages = GetDirectories(HttpContext.Current.Server.MapPath(contentPath + "/Pages/"));
            var menuItems = new List<MenuListItem>();

            foreach (var page in pages)
            {
                var configPath = string.Format("{0}\\config.xml", page);
                var config = new PageConfigModelBuilder().Build(configPath);
                var url = string.Format("/{0}/", Path.GetFileName(page));

                menuItems.Add(new MenuListItem
                    {
                        Text = config.Title,
                        Url = url,
                        Active = IsPageActive(url)
                    });
            }

            return menuItems;
        }

        public bool IsPageActive(string path)
        {
            var absolutePath = HttpContext.Current.Request.Url.AbsolutePath;
            return absolutePath == path;

        }

        private IEnumerable<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }
    }

    public class MenuListItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}