using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranApi.ViewModel.RecipeViewModel
{
    public class RecipeDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductRecipeViewModel> Product { get; set; }
        public RecipeDetailViewModel()
        {
            Product = new List<ProductRecipeViewModel>();
        }
    }
}