using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;

namespace RestoranWeb.Models
{
    public class RecipeLocationViewModel
    {
        public int Id { get; set; }
        public List<Location> RecipeLocation { get; set; }
        public List<Location> NoRecipeLocation { get; set; }
        public RecipeLocationViewModel()
        {
            RecipeLocation = new List<Location>();
            NoRecipeLocation = new List<Location>();
        }       
    }
}