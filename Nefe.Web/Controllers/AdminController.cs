using System.Web.Mvc;
using Nefe.Web.Attributes;

namespace Nefe.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
