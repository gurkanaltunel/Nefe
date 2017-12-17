using System.Collections.Generic;

namespace Nefe.Domain
{
    public class ProductPackage : Entity
    {
        public string PackageName { get; set; }
        public ICollection<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
