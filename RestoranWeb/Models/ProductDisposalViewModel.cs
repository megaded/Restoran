using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranWeb.Models
{
    public class ProductDisposalViewModel
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public string UnitSymbol { get; set; }
        public double Amount { get; set; }
        public double AmountDispocal { get; set; }
    }
}