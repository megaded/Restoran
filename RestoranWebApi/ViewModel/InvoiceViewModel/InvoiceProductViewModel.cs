using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranApi.ViewModel.InvoiceViewModel
{
    public class InvoiceProductViewModel
    {
        public int InvoiceId { get; set; }
        public List<ProductInvoiceViewModel> Products { get; set; }
    }
}