using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranDesktop.Model;
using RestoranDesktop.View.Order;
using RestoranSDK;

namespace RestoranDesktop.ViewModel.Location
{
    public class LocationSuppliersViewModel
    {
        private int locationId { get; set; }
        private LocationAPI locationApi;
        public ObservableCollection<Supplier> Suppliers { get; set; }

        public LocationSuppliersViewModel(int locatonId)
        {
            this.locationId = locatonId;
            locationApi=new LocationAPI();
            var suppliers = locationApi.GetSupplier(this.locationId).Select(x=>new Supplier()
            {
                Id=x.Id,
                Name = x.Name,
                OpenCommand = new Command((() =>
                {
                    
                }))
            });
            Suppliers=new ObservableCollection<Supplier>(suppliers);
        }

        private void Open()
        {
            var view=new OrderCreateView();

        }
    }
}
