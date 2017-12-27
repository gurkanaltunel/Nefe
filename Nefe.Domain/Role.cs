using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nefe.Domain
{
    public class Role : Entity
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string RoleName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
