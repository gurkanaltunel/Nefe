using System.Web.Mvc;
using Nefe.Web.Security;

namespace Nefe.Web.Controllers
{
    /// <summary>
    /// Controller larda ihtiyaç duyulan ortak özellikleri taşıyan component
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// User a ait bilgileri taşır
        /// </summary>
        protected new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
}
