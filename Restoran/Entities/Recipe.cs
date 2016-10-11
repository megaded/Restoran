using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Restoran
{
    
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Required(ErrorMessage ="Введите название")]
        [StringLength(30,ErrorMessage ="Не более 30 символов")]
        public string Name { get; set; }
        [StringLength(200, ErrorMessage = "Не более 200 символов")]
        public string Description { get; set; }
        public virtual List<ProductRecipe> Products { get; set; }
        public virtual List<Location> Locations { get; set; }       
        public Recipe()
        {
            Products = new List<ProductRecipe>();
        }
    }
}
