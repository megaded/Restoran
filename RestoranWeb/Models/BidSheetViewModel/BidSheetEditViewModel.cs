using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;
using System.Web.Mvc;

namespace RestoranWeb.Models.BidSheetViewModel
{
    public class BidSheetEditViewModel
    {
        public int MarketId { get; set; }
        public SelectList Suppliers { get; set; }
        public int SupplierId { get; set; }
    }
}