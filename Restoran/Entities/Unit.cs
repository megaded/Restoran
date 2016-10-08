﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    // Единица измерения
  public class Unit
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
