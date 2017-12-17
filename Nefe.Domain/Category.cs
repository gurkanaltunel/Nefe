﻿using System.Collections.Generic;

namespace Nefe.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
