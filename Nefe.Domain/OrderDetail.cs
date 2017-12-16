using System.ComponentModel.DataAnnotations;

namespace Nefe.Domain
{
    public class OrderDetail : Entity
    {
        [Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
    }
}
