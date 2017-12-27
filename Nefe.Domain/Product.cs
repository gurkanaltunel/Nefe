using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nefe.Domain
{
    public class Product : Entity
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Descripton { get; set; }
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
        public DateTime? SeasonDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductPackageId { get; set; }
        public ProductPackage ProductPackage { get; set; }
    }
}
