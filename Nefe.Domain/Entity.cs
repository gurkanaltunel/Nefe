using System;

namespace Nefe.Domain
{
    public abstract class Entity
    {
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
