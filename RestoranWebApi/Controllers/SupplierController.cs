using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.SupplierViewModel;

namespace RestoranApi.Controllers
{
    [RoutePrefix("supplier")]
    public class SupplierController : ApiController
    {
        private readonly RestoranContext context;
        public SupplierController()
        {
            context = new RestoranContext();
        }
        /// <summary>
        /// Получение списка всех поставщиков.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllSupplier()
        {
            var supplier = context.Supplier.ToList();           
            var model = supplier.Select(x => new SupplierViewModel
            {
                Id=x.SupplierId,
                Name=x.Name
            });
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Получение информации о поставщике
        /// </summary>
        /// <param name="supplierId">Id поставщика</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{supplierId:int}")]
        public HttpResponseMessage Get(int supplierId)
        {
            var model=new SupplierViewModel();
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}
