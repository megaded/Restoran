using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranApi.ViewModel.RecipeViewModel
{
    public class ProductRecipeViewModel
    {
        public int ProductRecipeId { get; set; }
        public string ProductName { get; set; }
        public double Value { get; set; }
    }
}