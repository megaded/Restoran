using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restoran.Repositories
{
    public class ProductOrderedARepository : IProductOrderedRepository
    {
        private readonly RestoranContext context;
        public ProductOrderedARepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(ProductOrdered entity)
        {
            context.ProductOrdered.Add(entity);
        }
        public ProductOrdered Get(int id)
        {
            return context.ProductOrdered.Find(id);
        }
        public IEnumerable<ProductOrdered> GetAll()
        {
            return context.ProductOrdered.ToList();
        }
        public void Remove(ProductOrdered entity)
        {
            context.ProductOrdered.Remove(entity);
        }
        public void Update(ProductOrdered entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
