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
        public OrdersListViewModel(List<Order> orders)
        {
            AccertOrders = new List<Order>();
            NotAcceptOrders = new List<Order>();
            foreach (var order in orders)
            {
                if (order.Accept)
                    AccertOrders.Add(order);
                else
                    NotAcceptOrders.Add(order);
            }
        } 
    }
}