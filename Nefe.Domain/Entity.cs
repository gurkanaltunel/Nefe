using System;
using System.ComponentModel.DataAnnotations;

namespace Nefe.Domain
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
