using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDesktop.Model
{
   public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public string VATInvoice { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
        public int LocationId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public int OrderId { get; set; }
        public virtual List<ProductInvoice> Products { get; set; }
    }
}
