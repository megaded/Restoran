using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranWeb.Models.BidSheetViewModel
{
    public class BidSheetViewModel
    {
        public int MarkerId { get; set; }
        public SelectList Markets { get; set; }
    }
}