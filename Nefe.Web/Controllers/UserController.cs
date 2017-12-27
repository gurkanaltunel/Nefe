using System.Web.Mvc;
using Nefe.Web.Attributes;

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

        public ActionResult WishList()
        {
            return View("WishList");
        }

    }
}
