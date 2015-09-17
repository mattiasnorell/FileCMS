using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace FileCms.Controllers
{
    public class AdministrationController : Controller
    {
        //
        // GET: /Page/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string pwd)
        {
            var password = ConfigurationManager.AppSettings["AdminPassword"];
            var sBuilder = new StringBuilder();

            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                foreach (var t1 in data)
                {
                    sBuilder.Append(t1.ToString("x2"));
                }
            }

            var authenticated = sBuilder.ToString() == password;
            
            return RedirectToAction(authenticated ? "Packages" : "Index");
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Packages()
        {
            return View();
        }

        public ActionResult UploadPackage()
        {
            return new EmptyResult();
        }

        public ActionResult DeletePackage()
        {
            return new EmptyResult();
        }
    }
}
