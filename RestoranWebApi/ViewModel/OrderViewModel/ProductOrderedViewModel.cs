using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranApi.ViewModel.OrderViewModel
{
    public class ProductOrderedViewModel
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
    }
}