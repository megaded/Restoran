using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSDK.DTO
{
   public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public string Market { get; set; }
    }
}
