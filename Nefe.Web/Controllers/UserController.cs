using System.Web.Mvc;
using Nefe.Web.Security;

namespace Nefe.Web.Controllers
{
    /// <summary>
    /// Kullanıcı paneline ait işlemlerin yönetildiği component
    /// </summary>
    [CustomAuthorize(Roles = "User")]
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View("WishList");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        public ActionResult WishList()
        {
            return View("WishList");
        }

    }
}
