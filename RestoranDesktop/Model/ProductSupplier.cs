using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDesktop.Model
{
 public   class ProductSupplier
    {
        public int ProductId { get; set; }
        public string ProductName  { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public int SupplierId { get; set; }

    }
}
