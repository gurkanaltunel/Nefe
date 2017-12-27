using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nefe.Domain
{
    public class Category : Entity
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
