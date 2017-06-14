using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using RestoranDesktop.Model;
using RestoranDesktop.View.Location;
using RestoranSDK;

namespace RestoranDesktop.ViewModel.Location
{
    public class LocationsViewModel
    {
        private  LocationAPI locationApi;
        public ObservableCollection<Model.Location> Locations { get; set; }

   


        public LocationsViewModel()
        {
            locationApi=new LocationAPI();
            var location = locationApi.GetAll().Select(x => new Model.Location
            {
                Id = x.Id,
                Name = x.Name,
                Detail = new Command((() =>
                {
                    Detail(x.Id);
                }))
            });
            Locations=new ObservableCollection<Model.Location>(location);
        }


        private void Detail(int locationId)
        {
            var view=new LocationMenuView();
            var viewmodel=new LocationMenuViewModel(locationId);
            view.DataContext = viewmodel;
            view.Show();
        }
        private void Edit(int locationId)
        {
            locationApi=new LocationAPI();

        }
        private void Delete(int locationId )
        {
           
        }        
    }
}
