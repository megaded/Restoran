using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranDesktop.Model;
using RestoranDesktop.View.Location;
using RestoranDesktop.View.Order;
using RestoranDesktop.ViewModel.Order;
using RestoranSDK;

namespace RestoranDesktop.ViewModel.Location
{
    public class LocationMenuViewModel
    {
        private readonly int locationId;
        private LocationAPI locationApi;
        public List<LocationItemMenu> Menu { get; set; }

        public LocationMenuViewModel(int locationId)
        {
            this.locationId = locationId;
            locationApi = new LocationAPI();
            #region Create Menu

            Menu = new List<LocationItemMenu>();

            var productItemMenu = new LocationItemMenu()
            {
                NameMenu = "Продукты",
                Open = new Command((() =>
                {
                    var view = new LocationProductsView();
                    var viewmodel = new LocationProductsViewModel(this.locationId);
                    view.DataContext = viewmodel;
                    view.ShowDialog();

                }))
            };
            var recipeItemMenu = new LocationItemMenu()
            {
                NameMenu = "Рецепты",
                Open = new Command((() =>
                {
                    var view = new LocationRecipesView();
                    var viewmodel = new LocationRecipeViewModel(locationId);
                    view.DataContext = viewmodel;
                    view.ShowDialog();
                }))
            };
            var supplierItemMenu = new LocationItemMenu()
            {
                NameMenu = "Поставщики",
                Open = new Command((() =>
                {
                    var view = new LocationSuppliersView();
                    var viewmodel = new LocationSuppliersViewModel(this.locationId);
                    view.DataContext = viewmodel;
                    view.ShowDialog();
                }))
            };
            var orderItemMenu = new LocationItemMenu()
            {
                NameMenu = "Просмотр заказов",
                Open = new Command((() =>
                {
                    var view = new OrderView();
                    var viewmodel = new OrderViewModel(this.locationId);
                    view.DataContext = viewmodel;
                    view.ShowDialog();
                }))
            };

            var orderCreateItemMenu = new LocationItemMenu()
            {
                NameMenu = "Создать заказ",
                Open = new Command((() =>
                {
                    var view = new OrderCreateView();
                    var viewmodel = new OrderCreateViewModel(this.locationId);
                    view.DataContext = viewmodel;
                    view.ShowDialog();
                }))
            };

            Menu.Add(productItemMenu);
            Menu.Add(recipeItemMenu);
            Menu.Add(supplierItemMenu);
            Menu.Add(orderCreateItemMenu);
            Menu.Add(orderItemMenu);

            #endregion
        }
    }
}
