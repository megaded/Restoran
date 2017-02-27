using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
  public  class ProductTransfer
    {
        public int ProductTransferId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public double Value { get; set; }
        public decimal Price { get; set; }
    }
}
