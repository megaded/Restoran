﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Единица измерения
    /// </summary>
    public class Unit
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
