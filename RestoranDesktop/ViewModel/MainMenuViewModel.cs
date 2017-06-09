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
using RestoranDesktop.View.Unit;

namespace RestoranDesktop.ViewModel
{
 public class MainMenuViewModel:INotifyPropertyChanged
    {
        private UserControl currentPage { get; set; }
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
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
            Menu=new ObservableCollection<ItemMenu>();
            ItemMenu product=new ItemMenu();
            product.Name = "Продукт";
            Command command = new Command();
            command.Action+=()=>
            {
                ProductsView view=new ProductsView();
                CurrentPage = view;
            };
            product.Open = command;

            ItemMenu unit = new ItemMenu();
            unit.Name = "Единицы измерения";
            command = new Command();
            command.Action += () =>
            {
                UnitsView view = new UnitsView();
                CurrentPage = view;
            };
            unit.Open = command;

            ItemMenu recipe = new ItemMenu();
            recipe.Name = "Рецепты";
            command = new Command();
            command.Action += () =>
            {
                ProductsView view = new ProductsView();
                
            };
            recipe.Open = command;

            ItemMenu provider = new ItemMenu();
            provider.Name = "Поставщики";
            command = new Command();
            command.Action += () =>
            {
                ProductsView view = new ProductsView();
                CurrentPage = view;

            };
            ItemMenu location = new ItemMenu();
            location.Name = "Локации";
            command = new Command();
            command.Action += () =>
            {
                LocationView view = new LocationView();
                CurrentPage = view;

            };
            location.Open = command;

            Menu.Add(product);
            Menu.Add(unit);
            Menu.Add(location);
            Menu.Add(recipe);
            Menu.Add(provider);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
