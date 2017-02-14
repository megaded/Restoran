﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public string VATInvoice { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public virtual ICollection<ProductInvoice> Products { get; set; }
        public Invoice()
        {
            Products = new List<ProductInvoice>();
        }
    }
}