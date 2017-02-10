using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranWeb.Models.LocationViewModel
{
    public class LocationViewModel
    {
        public string Name { get; set; }
        public int MarketId { get; set; }
        public SelectList Markets { get; set; }
        public int LocationId { get; set; }
    }
}