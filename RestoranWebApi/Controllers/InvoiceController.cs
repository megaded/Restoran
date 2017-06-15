using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.InvoiceViewModel;

namespace RestoranApi.Controllers
{
    [RoutePrefix("invoice")]
    public class InvoiceController : ApiController
    {
        private readonly RestoranContext context;

        public InvoiceController()
        {
            context = new RestoranContext();
        }

        /// <summary>
        /// Получение информации о накладной
        /// </summary>
        /// <param name="invoiceId">Id накладной</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{invoiceId:int}")]
        public HttpResponseMessage Get(int invoiceId)
        {
            var entity = context.Invoice.Find(invoiceId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var model=new InvoiceViewModel()
            {
                InvoiceId = entity.InvoiceId,
                VATInvoice = entity.VATInvoice,
                Date = entity.Date,
                InvoiceNumber = entity.InvoiceNumber,
                LocationId = entity.LocationId,
                OrderId = entity.OrderId,
                SupplierId =entity.SupplierId,
                SupplierName = entity.Supplier.Name,
                TotalPrice=entity.TotalPrice,
                TotalPriceWithTax = entity.TotalPriceWithTax
            };
            return Request.CreateResponse(HttpStatusCode.OK,model);
        }

        /// <summary>
        /// Получение продуктов в накладной
        /// </summary>
        /// <param name="invoiceId">Id накладной</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{invoiceId:int}/product")]
        public HttpResponseMessage GetProducts(int invoiceId)
        {
            var entity = context.Invoice.Find(invoiceId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var products = context.ProductsInvoice.Where(x => x.InvoiceId == entity.InvoiceId);
            var model = new InvoiceProductViewModel()
            {
                InvoiceId = entity.InvoiceId,
                Products = products.Select(x => new ProductInvoiceViewModel()
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Price = x.Price,
                    Value = x.Value,
                    Tax = x.Tax
                }).ToList()
            };
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }


    }
}
