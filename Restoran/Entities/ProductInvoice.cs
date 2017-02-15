using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    public class ProductInvoice
    {
        public int ProductInvoiceId { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
    }
}
