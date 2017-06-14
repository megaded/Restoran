using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoranApi.ViewModel.OrderViewModel
{
    public class OrderLocationViewModel
    {
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}