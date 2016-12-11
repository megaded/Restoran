using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran.Repositories
{
    public class ProductDisposalRepository : IProductDisposalRepository
    {
        private readonly RestoranContext context;
        public ProductDisposalRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(ProductDisposal entity)
        {
            context.ProductDisposal.Add(entity);
        }

        public ProductDisposal Get(params object[] keysValue)
        {
            return context.ProductDisposal.Find(keysValue);
        }

        public IEnumerable<ProductDisposal> GetAll()
        {
            return context.ProductDisposal.ToList();
        }

        public void Remove(ProductDisposal entity)
        {
            context.ProductDisposal.Remove(entity);
        }

        public void Update(ProductDisposal entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
