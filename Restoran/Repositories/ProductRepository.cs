using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restoran.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RestoranContext context;
        public ProductRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(Product entity)
        {
            context.Product.Add(entity);
            context.SaveChanges();
        }

        public Product Get(params object[] keysValue)
        {
            return context.Product.Find(keysValue);
        }

      
        public IEnumerable<Product> GetAll()
        {
            return context.Product.ToList();
        }
        public void Remove(Product entity)
        {
            context.Product.Remove(entity);
        }
        public void Update(Product entity)
        {
            var target = context.Product.Find(entity.ProductId);
            if (target != null)
            {
                target.Name = entity.Name;
                target.ProductCategoryId = entity.ProductCategoryId;
                target.UnitId = entity.UnitId;
                target.Description = entity.Description;
            }
        }
    }
}
