using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.RecipeViewModel;

namespace RestoranApi.Controllers
{
    [RoutePrefix("recipe")]
    public class RecipeController : ApiController
    {
        private RestoranContext context;
        public RecipeController()
        {
            context = new RestoranContext();
        }

        [HttpGet]    
        [Route("all")]      
        public HttpResponseMessage GetAllRecipe()
        {
            var recipes = context.Recipe.ToList();
            if(recipes == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Рецептов нет");
            }
            var model = recipes.Select(x => new RecipeViewModel
            {
                Id = x.RecipeId,
                Name =x.Name,
                Description=x.Description
            });
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetRecipe(int id)
        {
            var recipe = context.Recipe.Find(id);
            if (recipe == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Рецептов нет");
            }
            var model = new RecipeDetailViewModel();
            model.Id = recipe.RecipeId;
            model.Name = recipe.Name;
            model.Description = recipe.Description;
            model.Product = recipe.Products.Select(x => new ProductRecipeViewModel
            {
                ProductRecipeId=x.ProductRecipeId,
                Value=(double)x.Value,
                ProductName=x.Product.Name
            }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

    }
}
