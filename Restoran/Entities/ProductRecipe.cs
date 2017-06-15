using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restoran
{
    /// <summary>
    /// Продукт в рецепте
    /// </summary>
  public  class ProductRecipe:IComponent
    {
        [Range(0,100000,ErrorMessage ="Количество должно быть больше 0")]
        public double? Value { get; set; }
        public int ProductRecipeId { get; set; }
        public int? RecipeId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual  Recipe Recipe { get; set; }                      
    }
}
