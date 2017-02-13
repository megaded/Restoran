using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranWeb.Models.CalculationCardViewModel
{
    public class CalculationCardViewModel
    {
        public string RecipeName { get; set; }
        public List<ProductCard> ProductsCard { get; set; }
        public CalculationCardViewModel()
        {
            ProductsCard = new List<ProductCard>();
        }
        public class ProductCard
        {
            public string ProductName { get; set; }
            public double Value { get; set; }
            public decimal Price { get; set; }
        }
    }
       
}