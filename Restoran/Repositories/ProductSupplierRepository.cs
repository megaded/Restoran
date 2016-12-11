using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran.Repositories
{
    public class ProductSupplierRepository : IProductSupplierRepository
    {
        private readonly RestoranContext context;
        public ProductSupplierRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(ProductSupplier entity)
        {
            context.ProductSupplier.Add(entity);
        }

        public ProductSupplier Get(params object[] keysValue)
        {
          return  context.ProductSupplier.Find(keysValue);
        }

       

        public ProductSupplier Get(int supplierId, int marketId,int productId)
        {
          return  context.ProductSupplier.Find(new[] { supplierId, marketId, productId });
        }

        public IEnumerable<ProductSupplier> GetAll()
        {
            return context.ProductSupplier;
        }

        public void Remove(ProductSupplier entity)
        {
            context.ProductSupplier.Remove(entity);
        }

        public void Update(ProductSupplier entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
