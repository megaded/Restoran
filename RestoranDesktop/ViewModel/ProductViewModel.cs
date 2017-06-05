using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Restoran;
using RestoranDesktop.Model;


namespace RestoranDesktop.ViewModel
{
   public class ProductViewModel
   {
       private readonly RestoranContext context;
        public ObservableCollection<Model.Product> Products { get; set; }
       public ProductViewModel()
       {
           context = new RestoranContext();
           var products = context.Product.ToList();
           var productviewModel = products.Select(x => new Model.Product()
           {
               Name = x.Name,
               Description=x.Description,
               Unit = x.Unit.Name,
               Category =x.ProductCategory.Name,
               Detail = new Command(() =>
                   {
                      var view=new View.Product();
                       view.DataContext=new Model.Product()
                       {
                           Name = x.Name,
                           Description = x.Description,
                           Unit=x.Unit.Name,
                           Category = x.ProductCategory.Name
                       };
                       view.ShowDialog();
                   }
                    )
           });
            Products=new ObservableCollection<Model.Product>(productviewModel);            
       }
    }
}
