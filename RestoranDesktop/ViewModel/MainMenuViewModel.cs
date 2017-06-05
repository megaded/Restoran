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
            Command productOpenCommand = new Command();
            productOpenCommand.Action+=()=>
            {
                Products view=new Products();
                view.ShowDialog();
            };
            product.Open = productOpenCommand;
            Menu.Add(product);
        }
    }
}
