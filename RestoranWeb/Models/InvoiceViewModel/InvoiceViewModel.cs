using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;

namespace RestoranWeb.Models.InvoiceViewModel
{
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public string VATInvoice { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set;}
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public List<ProductInvoiceViewModel> Products { get; set; }
        public InvoiceViewModel()
        {
            Products = new List<ProductInvoiceViewModel>();
        }
    }

}