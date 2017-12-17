using System.Linq;
using System.Security.Principal;

namespace Nefe.Web.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
        public IIdentity Identity { get; private set; }

        public CustomPrincipal(string eMail)
        {
            Identity = new GenericIdentity(eMail);
        }

        public bool IsInRole(string role)
        {
            return Roles.Any(role.Contains);
        }
    }
}