using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;

namespace RestoranWeb.Models.MarketViewModel
{
    public class MarketEditViewModel
    {
        public int Id { get; set; }
        public List<Supplier> MarketSupplier { get; set;}
        public List<Supplier> NoMarketSupplier { get; set; }
        public MarketEditViewModel()
        {
            MarketSupplier = new List<Supplier>();
            NoMarketSupplier = new List<Supplier>();
        }
    }
}