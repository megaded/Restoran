using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;

namespace RestoranWeb.Models
{
    public class OrderCreateViewModel
    {
        public List<ProductSupplier> Products { get; set; }  
        public List<ProductOrdered> ProductOrdered { get; set; }
        public OrderCreateViewModel(List<ProductSupplier> products)
        {
            ProductOrdered = new List<ProductOrdered>();
            foreach (var product in products)
            {
                ProductOrdered.Add( new ProductOrdered() { Product = product.Product,Price=product.Price });
            }
        }
        public OrderCreateViewModel()
        {

        }
    }
}