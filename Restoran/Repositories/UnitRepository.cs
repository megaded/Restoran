using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restoran.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly RestoranContext context;
        public UnitRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(Unit entity)
        {
            context.Unit.Add(entity);
            context.SaveChanges();
        }

        public Unit Get(params object[] keysValue)
        {
            return context.Unit.Find(keysValue);
        }     
        public IEnumerable<Unit> GetAll()
        {
            return context.Unit.ToList();
        }
        public void Remove(Unit entity)
        {
            context.Unit.Remove(entity);
        }
        public void Update(Unit entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
