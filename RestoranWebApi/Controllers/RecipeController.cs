using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.LocationViewModel;
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
            model.Products = recipe.Products.Select(x => new ProductRecipeViewModel
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
            foreach (var product in model.Products)
            {
                entity.Products.Add(new ProductRecipe { ProductId =product.ProductId, Value = product.Value });
            }
            entity=context.Recipe.Add(entity);
            context.SaveChanges();
            var recipe=new RecipeViewModel();
            recipe.Name = entity.Name;
            recipe.Id = entity.RecipeId;
            recipe.Description = entity.Description;            
            return Request.CreateResponse(HttpStatusCode.Created,recipe);
        }

        /// <summary>
        /// Получение списка локации у текущего рецепта.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("locations/{recipeId:int}")]
        public HttpResponseMessage GetRecipeLocation(int recipeId)
        {
            var entity = context.Recipe.Find(recipeId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var model=new RecipeLocationViewModel();
            model.Id = entity.RecipeId;
            model.Name = entity.Name;
            model.Locations = entity.Locations.Select(x => new LocationViewModel()
            {
                Id = x.ID,
                MarketId =x.MarketId,
                Market = x.Market.Name,
                Name = x.Name
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK,model);
        }

        /// <summary>
        /// Редактирование списка локации в рецепте.
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        [HttpPost]
        [Route("locations")]
        public HttpResponseMessage UpdateRecipeLocation(RecipeLocationViewModel model)
        {
            var entity = context.Recipe.Find(model.Id);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            entity.Locations.Clear();
            context.SaveChanges();
            foreach (var location in model.Locations)
            {
                var loc = context.Location.Find(location.Id);
                if (loc != null)
                {
                    entity.Locations.Add(loc);
                }             
            }
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Редактирование продуктов в рецепте.
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        [HttpPost]
        [Route("product")]
        public HttpResponseMessage UpdateRecipeProduct(RecipeDetailViewModel model)
        {
            var entity = context.Recipe.Find(model.Id);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            context.ProductRecipe.RemoveRange(entity.Products);
            entity.Products = model.Products.Where(y=>y.Value>0).Select(x => new ProductRecipe()
            {
               ProductId = x.ProductId,
               Value = x.Value,
               RecipeId =model.Id
            }).ToList();
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
