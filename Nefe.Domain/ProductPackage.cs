using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nefe.Domain
{
    public class ProductPackage : Entity
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string PackageName { get; set; }
        public ICollection<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
