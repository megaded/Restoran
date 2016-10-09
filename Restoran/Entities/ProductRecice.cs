using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
  public  class ProductRecipe:IComponent
    {
        public double Value { get; set; }
        public int ProductRecipeId { get; set; }
        public int RecipeId { get; set; }
        public virtual Product Product { get; set; }
        public virtual  Recipe Recipe { get; set; }           
    }
}
