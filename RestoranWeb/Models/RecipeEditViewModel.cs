using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;
using Restoran.Repositories;

namespace RestoranWeb.Models
{
    public class RecipeEditViewModel
    {
        public Recipe EditRecipe { get; set; }
        public List<ProductRecipe> Products { get; set; }
        private readonly UnitOfWork unitOfWork;
        public RecipeEditViewModel(UnitOfWork unitOfWork, Recipe editRecipe)
        {
            
            this.unitOfWork = unitOfWork;
            EditRecipe = editRecipe;
            var recipeProduct = EditRecipe.Products.Select(x => x.Product);
            Products = unitOfWork.ProductRep.GetAll().Select(p => new ProductRecipe { Product = p }).Where(p2=>!recipeProduct.Any(p1=>p1.ProductId==p2.Product.ProductId)).ToList();
        }
    }
}