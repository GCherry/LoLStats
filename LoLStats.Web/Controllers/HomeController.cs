#region References

using System.Web.Mvc;

#endregion

namespace LoLStats.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Methods

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        #endregion
    }
}