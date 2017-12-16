using System.Web.Mvc;

namespace Nefe.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
