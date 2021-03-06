﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Продукт поставщика
    /// </summary>
    public class ProductSupplier
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int MarketId { get; set; }
        public virtual Market Market{ get; set; } 
    }
}
