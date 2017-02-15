using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranWeb.Models.InvoiceViewModel
{
    public class ProductInvoiceViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double OrderValue { get; set; }
        public double InvoiceValue { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public decimal PriceWithTax { get; set; }
    }
}