using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;
using RestoranWeb.Models.OrderViewModel;


namespace RestoranWeb.Models
{
    public class OrderCreateViewModel
    {
        public List<ProductOrderedViewModel> ProductOrdered { get; set; }
        public int SupplierId { get; set; }       
        public OrderCreateViewModel()
        {
            ProductOrdered = new List<ProductOrderedViewModel>();
        }
    }
}