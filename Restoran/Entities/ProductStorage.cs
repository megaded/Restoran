using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
   public class ProductStorage:IComponent
    {
        public double Value { get; set; }
        public int ProductStorageId { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalQuantity { get; set; }
        public virtual  Product Product { get; set; }
        public virtual Location Storage { get; set; }       
    }
}
