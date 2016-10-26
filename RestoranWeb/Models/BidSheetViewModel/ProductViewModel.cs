using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranWeb.Models.BidSheetViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
    }
}