using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Заказанный продукт
    /// </summary>
    public class ProductOrdered
    {
        public int ProductOrderedId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
