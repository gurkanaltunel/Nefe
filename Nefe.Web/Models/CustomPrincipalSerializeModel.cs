namespace Nefe.Web.Models
{
    public class CustomPrincipalSerializeModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
    }
}