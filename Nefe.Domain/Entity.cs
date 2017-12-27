using System;
using System.ComponentModel.DataAnnotations;

namespace Nefe.Domain
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        protected Entity()
        {
            IsActive = true;
            CreateDate = DateTime.UtcNow;
        }
    }
}
