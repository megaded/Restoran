using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
   public class Market
    {
        public int MarketId { get; set; }
        public string Name { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }
        public virtual List<Location> Locations { get; set; }
        public Market()
        {
            Suppliers = new List<Supplier>();
            Locations = new List<Location>();
        }
    }
}
