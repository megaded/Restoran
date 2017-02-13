using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    public class ProductsDetails
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
