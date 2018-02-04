using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Nefe.Web.Models;
using Newtonsoft.Json;
using RestSharp;
using Nefe.Web.Models.Account;

namespace Nefe.Web.Controllers
{
    /// <summary>
    /// Kullanıcı authentication & authorizaton işlemleri
    /// </summary>
    public class AccountController : BaseController
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, bool rememberMe = false)
        {
            RestClient client = new RestClient("http://localhost:53807/api/Account/");
            var request = new RestRequest("Login", Method.POST);
            request.AddJsonBody(new
            {
                email = email,
                password = password
            });
            var reponse = client.Execute(request).Content;
            if (reponse == null) return View();
            var user = JsonConvert.DeserializeObject<User>(reponse);
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
            var faCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
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
            RestClient client = new RestClient("http://localhost:53807/api/Account/");
            var request = new RestRequest("Register", Method.POST);
            request.AddJsonBody(user);
            var response = client.Execute(request);
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }
    }
}
