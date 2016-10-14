using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;


namespace RestoranWeb.Models
{
    public class OrderCreateViewModel
    {
        public List<ProductOrdered> ProductOrdered { get; set; }
        public int Id { get; set; }
        public OrderCreateViewModel(List<ProductSupplier> products,int supplierId)
        {
            Id = supplierId;
            ProductOrdered = new List<ProductOrdered>();
            foreach (var product in products)
            {
                ProductOrdered.Add( new ProductOrdered() { ProductId=product.Product.ProductId, Product = product.Product,Price=product.Price });
            }
        }
        public OrderCreateViewModel()
        {

        }
    }
}