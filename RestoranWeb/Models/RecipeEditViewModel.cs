using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;
using Restoran.Repositories;
using System.ComponentModel.DataAnnotations;

namespace RestoranWeb.Models
{
    public class RecipeEditViewModel
    {
        [Required(ErrorMessage ="Введите название")]
        public string Name { get; set; }
        public int RecipeId { get; set; }
        public string Description { get; set; }
        public List<ProductRecipe> RecipeProducts { get; set; }
        public List<Product> NoRecipeProducts { get; set; }
        private readonly UnitOfWork unitOfWork;
        public RecipeEditViewModel(UnitOfWork unitOfWork, int recipeId)
        {
            RecipeProducts =new List<ProductRecipe>();
            NoRecipeProducts = new List<Product>();
            this.unitOfWork = unitOfWork;
            var editRecipe = unitOfWork.RecipeRep.Get(recipeId);
            Name = editRecipe.Name;
            RecipeId = editRecipe.RecipeId;
            Description = editRecipe.Description;
            RecipeProducts = new List<ProductRecipe>();
            RecipeProducts.AddRange(editRecipe.Products);
            var allProducts = unitOfWork.ProductRep.GetAll();
            foreach (var product in allProducts)
            {
                if (!RecipeProducts.Any(p => p.ProductId == product.ProductId))
                {
                    NoRecipeProducts.Add(product);
                }
            }           
        }
        public RecipeEditViewModel()
        {

        }
        public void AddProduct(int productID)
        {
            var product = NoRecipeProducts.Find(p => p.ProductId == productID);
            if (product != null)
            {
                RecipeProducts.Add(new ProductRecipe { ProductId = productID, RecipeId = RecipeId, Value = 0,Product=product });
                NoRecipeProducts.Remove(product);
            }         
        }
        public void RemoveProduct(int productID)
        {
            var product = RecipeProducts.Find(p=>p.ProductId==productID);
            if (product != null)
            {
                NoRecipeProducts.Add(product.Product);
                RecipeProducts.Remove(product);
            }

        }
    }
}