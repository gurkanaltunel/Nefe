using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Nefe.Service.UnitOfWorks;
using Nefe.Web.Models;
using Newtonsoft.Json;

namespace Nefe.Web.Controllers
{
    /// <summary>
    /// Kullanıcı authentication & authorizaton işlemleri
    /// </summary>
    public class AccountController : BaseController
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, bool rememberMe=false)
        {
            var user = _unitOfWork.UserRepository.Select(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user == null) return View();
            var roles = user.Roles.Select(r => r.RoleName).ToArray();
            var customPrincipal = new CustomPrincipalSerializeModel
            {
                UserId = user.UserId,
                FirstName = user.Name,
                LastName = user.LastName,
                Roles = roles
            };
            var userData = JsonConvert.SerializeObject(customPrincipal);
            var formAuthTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(15), true, userData);
            var encrypt = FormsAuthentication.Encrypt(formAuthTicket);
            var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
            Response.Cookies.Add(faCookie);
            return roles.Contains("Admin") ? RedirectToAction("Index", "Admin") : RedirectToAction("Index", roles.Contains("User") ? "User" : "Home");
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", null);
        }
    }
}
