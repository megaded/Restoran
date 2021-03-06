﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime AcceptDate { get; set; }
        public virtual List<ProductOrdered> Products { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public bool Accept { get; set; }
        public Order()
        {
            OrderDate = DateTime.Now;
            AcceptDate = DateTime.Now;
            Products = new List<ProductOrdered>();           
        }   
    }
}
