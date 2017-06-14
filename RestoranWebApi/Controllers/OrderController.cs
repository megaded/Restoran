using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.OrderViewModel;

namespace RestoranApi.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : ApiController
    {
        private readonly RestoranContext context;

        public OrderController()
        {
            context = new RestoranContext();
        }


        /// <summary>
        /// Получение информации о заказе
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{orderId:int}")]
        public HttpResponseMessage Get(int orderId)
        {
            var order = context.Order.Find(orderId);
            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var model = new OrderDetailViewModel();
            var products = order.Products.Select(x => new ProductOrderedViewModel()
            {
                ProductName = x.Product.Name,
                ProductId = x.ProductId,
                Value = x.Value,
                Price = x.Price,
                Tax = x.Tax

            }).ToList();
            model.OrderId = order.OrderID;
            model.OrderDate = order.OrderDate;
            model.AcceptDate = order.AcceptDate;
            model.Accept = order.Accept;
            model.Products = products;
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            var model = context.Order.Select(x => new OrderViewModel()
            {
                OrderId = x.OrderID,
                SupplierId = x.SupplierId,
                SupplierName = x.Supplier.Name,
                AcceptDate = x.AcceptDate,
                OrderDate = x.OrderDate,
                Accept = x.Accept
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <param name="model">Модель заказа</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create(OrderDetailViewModel model)
        {
            var entity = new Order();
            entity.SupplierId = model.SupplierId;
            entity.LocationId = model.LocationId;
            entity.OrderDate = model.OrderDate;
            entity.AcceptDate = model.AcceptDate;
            entity.Accept = model.Accept;
            foreach (var product in model.Products)
            {
                var productEntity = context.Product.Find(product.ProductId);
                if (productEntity != null)
                {
                    entity.Products.Add(new ProductOrdered()
                    {
                        ProductId = product.ProductId,
                        Value = product.Value,
                        Tax = product.Tax,
                        Price = product.Price
                    });
                }
            }
            context.Order.Add(entity);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{orderId:int}")]
        public HttpResponseMessage Delete(int orderId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Обновление данных заказа
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <param name="model">Модель заказа</param>
        /// <returns></returns>
        [HttpPut]
        [Route("orderId:int")]
        public HttpResponseMessage Update(int orderId, OrderDetailViewModel model)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}