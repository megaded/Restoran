using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranWeb.Models
{
    public class DispocalViewModel
    {
        public List<ProductDisposalViewModel> Products { get; set; }
        public SelectList Reason { get; set; }
        public int ReasonId { get; set; }
    }
}