using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Продукт хранения в локации
    /// </summary>
    public class ProductStorage:IComponent
    {
        public int ProductStorageId { get; set; }
        public double Value { get; set; }      
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalQuantity { get; set; }
        public int ProductId { get; set; }
        public virtual  Product Product { get; set; }
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }       
    }
}
