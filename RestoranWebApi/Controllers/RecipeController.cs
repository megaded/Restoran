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
        /// <summary>
        /// Получение списка всех рецептов.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("recipes")]
        public HttpResponseMessage GetAllRecipe()
        {
            var recipes = context.Recipe.ToList();
            var model = recipes.Select(x => new RecipeViewModel
            {
                Id = x.RecipeId,
                Name = x.Name,
                Description = x.Description
            });
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Получение детальной информарции о рецепте.
        /// </summary>
        /// <param name="id">Id рецепта.</param>
        /// <returns></returns>
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
                ProductRecipeId = x.ProductRecipeId,
                Value = (double)(x.Value.HasValue ? x.Value : 0),
                ProductId =x.ProductId,
                ProductName = x.Product.Name
            }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Создание рецепта.
        /// </summary>
        /// <param name="model">Модель рецепта</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(RecipeDetailViewModel model)
        {
            var entity = new Recipe();
            entity.Name = model.Name;
            entity.Description = model.Description;
            foreach (var product in model.Product)
            {
                entity.Products.Add(new ProductRecipe { ProductId =product.ProductId, Value = product.Value });
            }
            context.Recipe.Add(entity);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

    }
}
