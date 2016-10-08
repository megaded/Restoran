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
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
