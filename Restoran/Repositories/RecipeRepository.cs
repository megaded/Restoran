using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restoran.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RestoranContext context;
        public RecipeRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(Recipe entity)
        {
            context.Recipe.Add(entity);
        }
        public Recipe Get(int id)
        {
            return context.Recipe.Find(id);
        }
        public IEnumerable<Recipe> GetAll()
        {
            return context.Recipe.ToList();
        }
        public void Remove(Recipe entity)
        {
            context.Recipe.Remove(entity);
        }
        public void Update(Recipe entity)
        {
            var recipe = context.Recipe.Find(entity.RecipeId);
            var productDelete = recipe.Products;
            context.ProductRecipe.RemoveRange(productDelete);
            if (recipe != null)
            {
                recipe.Name = entity.Name;
                recipe.Description = entity.Description;
                recipe.Products = entity.Products.Select(p => new ProductRecipe { ProductId = p.ProductId, RecipeId = entity.RecipeId, Value = p.Value }).Where(p => p.Value > 0).ToList();
            }
        }
    }
}
