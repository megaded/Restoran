using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.ProductCategoryViewModel;
using RestoranApi.ViewModel.ProductViewModel;

namespace RestoranApi.Controllers
{
    [RoutePrefix("category")]
    public class ProducCategoryController : ApiController
    {

        private readonly RestoranContext context;
        public ProducCategoryController()
        {
            this.context = new RestoranContext();
        }

        /// <summary>
        /// Получение списка категорий продуктов.
        /// </summary>
        /// <returns></returns>       
        [HttpGet]
        [Route("categories")]
        public HttpResponseMessage GetAllProductCategories()
        {
            var model = context.ProductCategory.Select(x => new ProductCategoryViewModel()
            {
                Name=x.Name,
                Id=x.ProductCategoryId
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Получение категории продукта по Id
        /// </summary>
        /// <param name="categoryId">Id категории продукта.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{categoryId:int}")]
        public HttpResponseMessage GetProductCategory(int categoryId)
        {
            var entity = context.ProductCategory.Find(categoryId);
            if (entity == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var model=new ProductCategoryViewModel();
            model.Id = entity.ProductCategoryId;
            model.Name = entity.Name;
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Создание новой категории продукта 
        /// </summary>
        /// <param name="model">Модель категории продукта</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(ProductViewModel model)
        {
            var entity=new ProductCategory();
            entity.Name = model.Name;
            context.ProductCategory.Add(entity);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Удаление категории продукта по Id
        /// </summary>
        /// <param name="categoryId">Id категории продукта</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{categoryId:int}")]
        public HttpResponseMessage Delete(int categoryId)
        {
            var entity = context.ProductCategory.Find(categoryId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            context.ProductCategory.Remove(entity);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Обновление информации о категории продукта
        /// </summary>
        /// <param name="model">Модель категории продукта</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(ProductCategoryViewModel model)
        {
            var entity = context.ProductCategory.Find(model.Id);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            entity.Name = model.Name;
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
