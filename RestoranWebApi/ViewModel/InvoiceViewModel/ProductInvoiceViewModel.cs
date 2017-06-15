using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranApi.ViewModel.InvoiceViewModel
{
    public class ProductInvoiceViewModel
    { 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
    }
}