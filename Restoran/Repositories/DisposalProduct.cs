using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran.Repositories
{
    public class DisposalProductRepository : IDisposalProductRepository
    {

        private readonly RestoranContext context;
        public DisposalProductRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(DisposalProduct entity)
        {
            context.DisposalProduct.Add(entity);
        }

        public DisposalProduct Get(params object[] keysValue)
        {
            return context.DisposalProduct.Find(keysValue);
        }

        public IEnumerable<DisposalProduct> GetAll()
        {
            return context.DisposalProduct.ToList();
        }

        public void Remove(DisposalProduct entity)
        {
            context.DisposalProduct.Remove(entity);
        }

        public void Update(DisposalProduct entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
