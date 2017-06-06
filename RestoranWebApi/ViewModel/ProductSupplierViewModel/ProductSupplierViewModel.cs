using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranApi.ViewModel.ProductSupplierViewModel
{
    public class ProductSupplierViewModel
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }       
    }
}