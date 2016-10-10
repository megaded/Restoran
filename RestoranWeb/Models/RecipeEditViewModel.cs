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
            Products = unitOfWork.ProductRep.GetAll().Select(p => new ProductRecipe { Product = p ,ProductId=p.ProductId}).Where(p2=>!recipeProduct.Any(p1=>p1.ProductId==p2.Product.ProductId)).ToList();
        }
        public RecipeEditViewModel()
        {

        }
        public void AddProduct(int productID)
        {
            var newProduct = Products.Where(p => p.Product.ProductId == productID).FirstOrDefault();
            if (newProduct != null)
            {
                EditRecipe.Products.Add(newProduct);
                Products.Remove(newProduct);
            }
        }
        public void RemoveProduct(int productID)
        {
            var deleteProduct = EditRecipe.Products.Where(p => p.Product.ProductId == productID).FirstOrDefault();
            if (deleteProduct != null)
            {
                Products.Add(deleteProduct);
                EditRecipe.Products.Remove(deleteProduct);
            }
        }
    }
}