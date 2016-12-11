using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Restoran.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestoranContext context;

        public OrderRepository(RestoranContext context)
        {
            this.context = context;
        }
        public void Add(Order entity)
        {
            context.Order.Add(entity);
        }

        public Order Get(params object[] keysValue)
        {
            return context.Order.Find(keysValue);
        }

 

        public IEnumerable<Order> GetAll()
        {
            return context.Order.ToList();
        }

        public void Remove(Order entity)
        {
            context.Order.Remove(entity);
        }
        public void Update(Order entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
