using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nefe.Domain
{
    public class ProductPackage : Entity
    {
        [Key]
        public int ProductPackageId { get; set; }
        public string PackageName { get; set; }
        public ICollection<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
