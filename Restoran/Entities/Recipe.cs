using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restoran
{
    
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ProductRecipe> Products { get; set; }
        public virtual List<Location> Locations { get; set; }       
        public Recipe()
        {
            Products = new List<ProductRecipe>();
        }
    }
}
