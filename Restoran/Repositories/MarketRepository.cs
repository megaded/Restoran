using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran;

namespace Restoran.Repositories
{
    public class MarketRepository : IMarketRepository
    {
        private readonly RestoranContext context;
        public MarketRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(Market entity)
        {
            context.Market.Add(entity);
        }

        public Market Get(int id)
        {
            return context.Market.Find(id);
        }

        public IEnumerable<Market> GetAll()
        {
            return context.Market.ToList();
        }

        public void Remove(Market entity)
        {
            context.Market.Remove(entity);
        }

        public void Update(Market entity)
        {
            throw new NotImplementedException();
        }
    }
}
