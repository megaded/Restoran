using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.ProductViewModel;

namespace RestoranApi.Controllers
{
    public class ProductController : ApiController
    {
        private RestoranContext context;

        public ProductController()
        {
            context = new RestoranContext();
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
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
            return model;
        }
    }
}
