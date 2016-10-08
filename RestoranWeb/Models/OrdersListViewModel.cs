using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restoran;

namespace RestoranWeb.Models
{
    public class OrdersListViewModel
    {
        public List<Order> AccertOrders { get; set; }
        public List<Order> NotAcceptOrders { get; set; }      
    }
}