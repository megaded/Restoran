using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Restoran;
using RestoranApi.ViewModel.ProductViewModel;
using System.Text;

namespace RestoranApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : ApiController
    {
        private RestoranContext context;
        
        public ProductController()
        {
            context = new RestoranContext();
        }

        /// <summary>
        /// Получение всех продуктов.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllProducts()
        {
            var products = context.Product.ToList();
            var model = products.Select(x => new ProductViewModel
            {
                Id = x.ProductId,
                Name = x.Name,
                Description = x.Description,
                UnitId = x.UnitId,
                Unit = x.Unit.Symbol,
                ProductCategoryId = x.ProductCategoryId,
                ProductCategory = x.ProductCategory.Name
            });
            return Request.CreateResponse(HttpStatusCode.OK,model);
        }

        /// <summary>
        /// Получение информации о продукте по ключу
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{productId:int}")]
        public HttpResponseMessage GetProduct(int productId)
        {
            var entity = context.Product.Find(productId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Продукт не найден");
            }
            var model=new ProductViewModel();
            model.Id = entity.ProductId;
            model.Name = entity.Name;
            model.ProductCategoryId = entity.ProductCategoryId;
            model.ProductCategory = entity.ProductCategory.Name;
            model.UnitId = entity.UnitId;
            model.Unit = entity.Unit.Symbol;
            return Request.CreateResponse(HttpStatusCode.OK,model);
        }

        /// <summary>
        /// Создание продукта
        /// </summary>
        /// <param name="product">Модель продукта</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateProduct( [FromBody]ProductViewModel product)
        {           
            var model=new Product();
            model.Name = product.Name;
            model.UnitId = product.UnitId;
            model.Description = product.Description;
            model.ProductCategoryId = product.ProductCategoryId;
            context.Product.Add(model);
            context.SaveChanges();
            return Request.CreateResponse<ProductViewModel>(HttpStatusCode.Created,product);
        }

        /// <summary>
        /// Удаление продукта по ключу
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{productId:int}")]
        public HttpResponseMessage Delete(int productId)
        {
            var entity = context.Product.Find(productId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Продукт не найден");
            }
            context.Product.Remove(entity);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Продукт удален");
        }

        /// <summary>
        /// Обновление информации о продукте
        /// </summary>
        /// <param name="productId">Данные о продукте</param>
        /// <param name="product">Id продукта</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{productId:int}")]
        public HttpResponseMessage Update(int productId, [FromBody]ProductViewModel product)
        {
            var entity = context.Product.Find(productId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            entity.Name = product.Name;
            entity.UnitId = product.UnitId;
            entity.ProductCategoryId = product.ProductCategoryId;
            entity.Description = product.Description;
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    
    }
}
