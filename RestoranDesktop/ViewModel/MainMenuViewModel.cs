using RestoranDesktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Restoran;
using RestoranDesktop.View;
using RestoranDesktop.View.Location;
using RestoranDesktop.View.Recipe;
using RestoranDesktop.View.Unit;

namespace RestoranDesktop.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {

        private UserControl currentPage;
        public ObservableCollection<ItemMenu> Menu { get; set; }
        public UserControl CurrentPage
        {
            get { return this.currentPage; }
            set
            {
                this.currentPage = value;
                NotifyPropertyChanged("CurrentPage");
            }
        }
        public MainMenuViewModel()
        {
            Menu = new ObservableCollection<ItemMenu>();

            var product = new ItemMenu()
            {
                Name = "Продукт",
                Open = new Command((() =>
                {
                    var view = new ProductsView();
                    CurrentPage = view;
                }))
            };

            var unit = new ItemMenu()
            {
                Name = "Единицы измерения",
                Open = new Command((() =>
                {
                    var view = new UnitsView();
                    CurrentPage = view;
                }))
            };

            var recipe = new ItemMenu()
            {
                Name = "Рецепты",
                Open = new Command((() =>
                {
                    var view = new RecipeView();
                    CurrentPage = view;
                }))
            };

            var provider = new ItemMenu()
            {
                Name = "Поставщики",
                Open = new Command((() =>
                {
                    var view = new ProductsView();
                    CurrentPage = view;
                }))
            };

            var location = new ItemMenu()
            {
                Name = "Локации",
                Open = new Command((() =>
                {
                    var view = new LocationView();
                    CurrentPage = view;
                }))
            };

            Menu.Add(product);
            Menu.Add(unit);
            Menu.Add(location);
            Menu.Add(recipe);
            Menu.Add(provider);

        }


    }
}
