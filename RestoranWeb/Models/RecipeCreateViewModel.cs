using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.Repositories;
using Restoran;

namespace RestoranWeb.Models
{
    public class RecipeCreateViewModel
    {
        private readonly UnitOfWork unitOfwork;
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductRecipe> Products { get; set; } 
        public RecipeCreateViewModel()
        {
            Products = new List<ProductRecipe>();
        }
         
        public RecipeCreateViewModel(UnitOfWork unitOfwork)
        {
            this.unitOfwork = unitOfwork;
            Products = new List<ProductRecipe>();
            var products = unitOfwork.ProductRep.GetAll();
            foreach (var product in products)
            {
                Products.Add(new ProductRecipe { Product = product });
            }      
        }
    }
 
}
