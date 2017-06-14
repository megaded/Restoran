using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranDesktop.Model;
using RestoranSDK;

namespace RestoranDesktop.ViewModel.Location
{
    public class LocationProductsViewModel
    {
        private LocationAPI locationApi;

        public ObservableCollection<ProductStorage> Products { get; set; }

        public LocationProductsViewModel(int locationId)
        {
            locationApi = new LocationAPI();
            var products = locationApi.GetProduct(locationId).Select(x => new ProductStorage()
            {
                ProductName = x.Name,
                Price = x.Price,
                Value = x.Value,
                TotalPrice = x.Price * Convert.ToDecimal(x.Value)
            });
            Products=new ObservableCollection<ProductStorage>(products);
        }
    }
}
