using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restoran.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly RestoranContext context;
        public SupplierRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(Supplier entity)
        {
            context.Supplier.Add(entity);
        }

        public Supplier Get(int id)
        {
            return context.Supplier.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Supplier.ToList();
        }

        public void Remove(Supplier entity)
        {
            context.Supplier.Remove(entity);
        }

        public void Update(Supplier entity)
        {
            context.Entry(entity).State = EntityState.Modified;
;        }
    }
}
