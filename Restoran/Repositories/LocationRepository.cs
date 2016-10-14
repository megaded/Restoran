using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Restoran.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly RestoranContext context;
        public LocationRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(Location entity)
        {
            context.Location.Add(entity);
        }       
        public Location Get(int id)
        {
            return context.Location.Find(id);
        }
        public IEnumerable<Location> GetAll()
        {
            return context.Location.ToList();
        }
        public void Remove(Location entity)
        {
            context.Location.Remove(entity);
        }
        public void Update(Location entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
