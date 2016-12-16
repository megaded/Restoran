using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranWeb.Models.Recipe
{
    public class RecipeDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RecipeComponentViewModel> Components { get; set; }
        public List<string> Locations { get; set; }
        public RecipeDetailViewModel()
        {
            Components = new List<RecipeComponentViewModel>();
            Locations = new List<string>();
        }
    }
}