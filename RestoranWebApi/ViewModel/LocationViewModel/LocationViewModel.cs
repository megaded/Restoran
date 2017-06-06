using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranApi.ViewModel.LocationViewModel
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public string Market { get; set; }
    }
}