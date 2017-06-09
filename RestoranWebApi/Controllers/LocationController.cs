using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.LocationViewModel;
using RestoranApi.ViewModel.ProductStorageViewModel;
using RestoranApi.ViewModel.RecipeViewModel;
using RestoranApi.ViewModel.SupplierViewModel;
using RestoranApi.ViewModel.ProductSupplierViewModel;

namespace RestoranApi.Controllers
{
    [RoutePrefix("location")]
    public class LocationController : ApiController
    {
        private readonly RestoranContext context;

        public LocationController()
        {
            context = new RestoranContext();
        }
        /// <summary>
        /// Получение списка всех локаций.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("locations")]
        public HttpResponseMessage GetAllLocation()
        {
            var locations = context.Location.ToList();
            var model = locations.Select(x => new LocationViewModel
            {
                Id = x.ID,
                Name = x.Name,
                MarketId = x.MarketId,
                Market = x.Market.Name,
            });
            return Request.CreateResponse(HttpStatusCode.OK,model);
        }

        /// <summary>
        /// Получение списка всех продуктов привязанных указанной локации.
        /// </summary>
        /// <param name="location">Id локации.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{location:int}/products")]
        public HttpResponseMessage GetProductsLocation(int location)
        {
            var entity = context.Location.Find(location);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format($"Локация {location} не найдена."));
            }
            var model = entity.Products.Select(x => new ProductStorageViewModel
            {
                Id = x.ProductStorageId,
                Name = x.Product.Name,
                Value = x.Value,
                Price = x.Price
            });
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Получение всех рецептов в указанной локации.
        /// </summary>
        /// <param name="location">Id локации.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{location:int}/recipes")]
        public HttpResponseMessage GetRecipeLocation(int location)
        {
            var entity = context.Location.Find(location);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format($"Локация {location} не найдена."));
            }
            var model = entity.Recipes.Select(x => new RecipeViewModel
            {
                Id = x.RecipeId,
                Name = x.Name,
                Description = x.Description
            });
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Получение списка всех поставщиков указанной локации.
        /// </summary>
        /// <param name="location">Id локации.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{location:int}/supplier")]
        public HttpResponseMessage GetSupplierLocation(int location)
        {
            var entity = context.Location.Find(location);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Нет локации");
            }
            var suppliers = context.Market.Find(entity.MarketId).Suppliers;
           
            var model = suppliers.Select(x => new SupplierViewModel
            {
                Id=x.SupplierId,
                Name=x.Name
            });
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Получение списка продуктов доступных у поставщика в указанной локации.
        /// </summary>
        /// <param name="location">Id лоокации</param>
        /// <param name="supplier">Id поставщика</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{location:int}/supplier/{supplier:int}/products")]
        public HttpResponseMessage GetSupplierProducts(int location, int supplier)
        {
            var entity = context.Location.Find(location);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Локации нет");
            }
            var products = context.Market.Find(location).Suppliers.Single(x => x.SupplierId == supplier).Products.Select(x => new ProductSupplierViewModel
            {
                Id=x.ProductId,
                Name=x.Product.Name,
                Price=x.Price,
                Tax=x.Tax
            });
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
