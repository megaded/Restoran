using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranSDK;

namespace RestoranDesktop.ViewModel.Order
{
    public class OrderViewModel
    {
        #region Private

        private LocationAPI locationApi;

        #endregion
        public ObservableCollection<Model.Order> NewOrders { get; set; }
        public ObservableCollection<Model.Order> AcceptedOrders { get; set; }

        public OrderViewModel(int locationId)
        {
            locationApi = new LocationAPI();
            var orders = locationApi.GetOrders(locationId).Select(x => new Model.Order()
            {
                OrderId = x.OrderId,
                SupplierName=x.SupplierName,
                OrderDate = x.OrderDate,
                AcceptDate = x.AcceptDate,
                Accept = x.Accept
            }).ToList();
            NewOrders = new ObservableCollection<Model.Order>(orders.Where(x => !x.Accept));
            AcceptedOrders = new ObservableCollection<Model.Order>(orders.Where(x => x.Accept));
        }
    }
}
