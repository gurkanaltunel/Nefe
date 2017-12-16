using System;
using System.ComponentModel.DataAnnotations;

namespace Nefe.Domain
{
    public class Product : Entity
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [MaxLength(50)]
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
        public UnitType UnitType { get; set; }
        public decimal TotalStockAmount { get; set; }
        public int StockPiece
        {
            get
            {
                return (int)(TotalStockAmount / Quantity);
            }
        }
        public bool StockStatus
        {
            get
            {
                return TotalStockAmount / Quantity > 0;
            }
        }
        public DateTime SeasonDate { get; set; }
        public Category Category { get; set; }
    }
}
