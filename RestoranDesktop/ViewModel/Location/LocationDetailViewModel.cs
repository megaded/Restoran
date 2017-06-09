using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranDesktop.Model;
using RestoranDesktop.View.Location;
using RestoranSDK;

namespace RestoranDesktop.ViewModel.Location
{
    public class LocationDetailViewModel
    {
        private readonly int locationId;
        private LocationAPI locationApi;
        public List<LocationItemMenu> Menu { get; set; }

        public LocationDetailViewModel(int locationId)
        {
            this.locationId = locationId;
            locationApi = new LocationAPI();
            Menu = new List<LocationItemMenu>();
            LocationItemMenu productItemMenu = new LocationItemMenu();
            productItemMenu.NameMenu = "Продукты";
            productItemMenu.Open = new Command((() =>
              {
                  var view = new LocationProductsView();
                  var viewmodel = new LocationProductsViewModel(this.locationId);
                  view.DataContext = viewmodel;
                  view.Show();
              }));
            LocationItemMenu recipeItemMenu = new LocationItemMenu();
            recipeItemMenu.NameMenu = "Рецепты";
            recipeItemMenu.Open = new Command((() =>
            {
               
            }));
            LocationItemMenu supplierItemMenu = new LocationItemMenu();
            supplierItemMenu.NameMenu = "Поставщики";
            supplierItemMenu.Open = new Command((() =>
              {

              }));
            LocationItemMenu orderItemMenu = new LocationItemMenu();
            orderItemMenu.NameMenu = "Заказать продукты";
            orderItemMenu.Open = new Command((() =>
              {

              }));
            Menu.Add(productItemMenu);
            Menu.Add(recipeItemMenu);
            Menu.Add(supplierItemMenu);
            Menu.Add(orderItemMenu);
        }
    }
}
