using System.Web.Mvc;

namespace Nefe.Web.Controllers
{
    /// <summary>
    /// Ana sayfa içeriğinin yönetildiği component
    /// </summary>
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View("Detail");
        }

        public ActionResult Products()
        {
            return View("Products");
        }

        public ActionResult ShoppingCart()
        {
            return View("ShoppingCart");
        }

        public ActionResult CheckOut()
        {
            return View("CheckOut");
        }

        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }

        public ActionResult ContactUs()
        {
            return View("ContactUs");
        }
    }
}
