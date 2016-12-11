using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restoran.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly RestoranContext context;
        public ProductCategoryRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(ProductCategory entity)
        {
            context.ProductCategory.Add(entity);
        }

        public ProductCategory Get(params object[] keysValue)
        {
            return context.ProductCategory.Find(keysValue);
        }


        public IEnumerable<ProductCategory> GetAll()
        {
            return context.ProductCategory.ToList();

        }

        public void Remove(ProductCategory entity)
        {
            context.ProductCategory.Remove(entity);
        }
        public void Update(ProductCategory entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
