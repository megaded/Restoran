using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{

    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public virtual Market Market { get; set; }
        public virtual ICollection<ProductStorage> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }   
        public virtual ICollection<Recipe> Recipes { get; set; }  
        public Location()
        {
            Products = new List<ProductStorage>();
            Orders = new List<Order>();
            Recipes = new List<Recipe>();
        }
    }
}
