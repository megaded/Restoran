using RestoranDesktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Restoran;
using RestoranDesktop.View;

namespace RestoranDesktop.ViewModel
{
 public class MainMenuViewModel
    {
        public ObservableCollection<ItemMenu> Menu { get; set; }
        public MainMenuViewModel()
        {
            Menu=new ObservableCollection<ItemMenu>();

            ItemMenu product=new ItemMenu();
            product.Name = "Продукт";
            Command command = new Command();
            command.Action+=()=>
            {
                Products view=new Products();
                view.ShowDialog();
            };
            product.Open = command;

            ItemMenu unit = new ItemMenu();
            unit.Name = "Единицы измерения";
            command = new Command();
            command.Action += () =>
            {
                Products view = new Products();
                view.ShowDialog();
            };
            unit.Open = command;

            ItemMenu recipe = new ItemMenu();
            recipe.Name = "Рецепты";
            command = new Command();
            command.Action += () =>
            {
                Products view = new Products();
                view.ShowDialog();
            };
            recipe.Open = command;

            ItemMenu provider = new ItemMenu();
            provider.Name = "Поставщики";
            command = new Command();
            command.Action += () =>
            {
                Products view = new Products();
                view.ShowDialog();
            };
            provider.Open = command;

            Menu.Add(product);
            Menu.Add(unit);
            Menu.Add(recipe);
            Menu.Add(provider);
        }
    }
}
