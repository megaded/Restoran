using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran.Repositories
{
    public class ReasonRepository : IReasonRepository
    {
        private readonly RestoranContext context;
        public ReasonRepository(RestoranContext context)
        {
            this.context = context;
        }

        public void Add(Reason entity)
        {
            context.Reason.Add(entity);
        }

        public void Remove(Reason entity)
        {
            context.Reason.Remove(entity);
        }


        public void Update(Reason entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public Reason Get(params object[] keysValue)
        {
            return context.Reason.Find(keysValue);
        }

        public IEnumerable<Reason> GetAll()
        {
            return context.Reason.ToList();
        }
    }
}
