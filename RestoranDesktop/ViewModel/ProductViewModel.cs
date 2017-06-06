using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
               ProductId = x.ProductId,
               Name = x.Name,
               Description=x.Description,
               Unit = x.Unit.Name,
               Category =x.ProductCategory.Name,
               Detail = new Command(() =>
                   {
                      DetailShow(x.ProductId);
                   }
                    ),
               Delete = new Command(() =>
               {
                Detele(x.ProductId);
               })
           });
            Products=new ObservableCollection<Model.Product>(productviewModel);            
       }

        private void DetailShow(int productID)
        {
            var productDetail = Products.Where(x => x.ProductId == productID).FirstOrDefault();
            var view=new View.Product();
            view.DataContext = productDetail;
            view.ShowDialog();
        }

        private void Detele(int productID)
        {
            var result = MessageBox.Show("Вы уверены", "Подтвердите удаление", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                var productRemove = context.Product.Find(productID);
                context.Product.Remove(productRemove);
                context.SaveChanges();
                Products.Remove(Products.Where(y => y.ProductId == productID).FirstOrDefault());
            }
        }        
    }
}
