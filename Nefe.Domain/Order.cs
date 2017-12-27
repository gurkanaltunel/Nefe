using System;
using System.Collections.Generic;

namespace Nefe.Domain
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
