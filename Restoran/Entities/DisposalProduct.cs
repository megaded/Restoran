using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
  public class DisposalProduct
    {
        public int DisposalProductId { get; set; }
        public double Amount { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductDisposalId { get; set; }
        public virtual ProductDisposal ProductDisposal { get; set; }       
    }
}
