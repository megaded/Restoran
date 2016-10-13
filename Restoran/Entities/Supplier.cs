﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    // Поставщик
    public class Supplier
    {
        public Supplier()
        {
            Products = new List<ProductSupplier>();
            Orders = new List<Order>();
        }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public virtual List<ProductSupplier> Products { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Market> Markets { get; set; }
     
    }
}
