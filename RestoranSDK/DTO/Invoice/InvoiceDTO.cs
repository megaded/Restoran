using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSDK.DTO.Invoice
{
   public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public string VATInvoice { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int LocationId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public int OrderId { get; set; }
    }
}
