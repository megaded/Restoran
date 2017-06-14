using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestoranDesktop.Model;
using RestoranSDK;
using RestoranSDK.DTO;

namespace RestoranDesktop.ViewModel.Order
{
    public class OrderCreateViewModel
    {
        #region Private

        private readonly LocationAPI locationApi;
        private  OrderAPI orderApi;
        private int locationId { get; set; }

        #endregion

        #region Property

        public ObservableCollection<Supplier> Suppliers { get; set; }
        public Supplier SelectedSupplier { get; set; }
        public ObservableCollection<ProductOrdered> Products { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        #endregion
        public OrderCreateViewModel(int locationId)
        {
            this.locationId = locationId;
            locationApi = new LocationAPI();
            var suppliers = locationApi.GetSupplier(locationId).Select(x => new Supplier()
            {
                Id = x.Id,
                Name = x.Name
            });
            Suppliers = new ObservableCollection<Supplier>(suppliers);
            SelectCommand = new Command(Select);
            Products = new ObservableCollection<ProductOrdered>();
            SaveCommand = new Command(Save);
        }

        private void Select()
        {
            var products = locationApi.GetProductSupplier(locationId, SelectedSupplier.Id).Select(x => new ProductOrdered()
            {
                ProductId = x.Id,
                ProductName = x.Name,
                Value = 0,
                Price = x.Price,
                Tax = x.Tax
            });
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        private void Save()
        {
            var model = new OrderDetailDTO();
            model.SupplierId = SelectedSupplier.Id;
            model.LocationId = this.locationId;
            model.OrderDate = DateTime.Now;
            model.AcceptDate = DateTime.Now;
            model.Accept = false;
            model.Products = Products.Where(x => !x.Value.Equals(0)).Select(x => new ProductOrderedDTO()
            {
                ProductId = x.ProductId,
                Value = x.Value,
                Price = x.Price,
                Tax = x.Tax
            }).ToList();
            orderApi = new OrderAPI();
            var resultFlag = orderApi.Create(model);
            if (resultFlag)
            {
                MessageBox.Show("Заказ создан");
            }
            if (!resultFlag)
            {
                MessageBox.Show("Ошибка создания заказа");
            }            
        }
    }
}
