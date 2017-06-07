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
    }
}
