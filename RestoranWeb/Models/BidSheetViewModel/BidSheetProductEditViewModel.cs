using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;

namespace RestoranWeb.Models.BidSheetViewModel
{
    public class BidSheetProductEditViewModel
    {
        public List<ProductViewModel> SupplierProducts { get; set; }
        public List<ProductViewModel> Products { get; set; }      
    }
}