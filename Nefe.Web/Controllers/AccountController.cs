using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Nefe.Domain;
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
        public ActionResult Login(string email, string password, bool rememberMe = false)
        {
            var user = _unitOfWork.UserRepository.Select(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user == null) return View();
            var roles = user.Roles.Select(r => r.RoleName).ToArray();
            var customPrincipal = new CustomPrincipalSerializeModel
            {
                UserId = user.Id,
                FirstName = user.Name,
                LastName = user.LastName,
                Roles = roles
            };
            var userData = JsonConvert.SerializeObject(customPrincipal);
            var formAuthTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(15), true, userData);
            var encrypt = FormsAuthentication.Encrypt(formAuthTicket);
            var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
            Response.Cookies.Add(faCookie);
            return roles.Contains("Admin") ? RedirectToAction("Index", "Admin") : RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(string name, string lastName, string email, string password, string confirmPassword)
        {
            var user = new User
            {
                Name = name,
                LastName = lastName,
                Email = email,
                Password = password,
            };
            user.Roles.Add(new Role { RoleName = "User", Description = "Standart role" });
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }
    }
}
