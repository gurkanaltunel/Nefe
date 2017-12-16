﻿using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nefe.Web.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }

        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated) return;
            var authorizedUsers = ConfigurationManager.AppSettings[UsersConfigKey];
            var authorizedRoles = ConfigurationManager.AppSettings[RolesConfigKey];
            Users = string.IsNullOrEmpty(Users) ? authorizedUsers : Users;
            Roles = string.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;
            if (!string.IsNullOrEmpty(Users))
            {
                if (!Users.Contains(CurrentUser.UserId.ToString()))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
                }
            }
            if (string.IsNullOrEmpty(Roles)) return;
            if (!CurrentUser.IsInRole(Roles))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }
        }
    }
}