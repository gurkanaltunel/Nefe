using System.Collections.Generic;

namespace Nefe.Domain
{
    public class Role : Entity
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
