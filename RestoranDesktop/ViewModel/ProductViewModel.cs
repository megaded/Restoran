using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Restoran;
using RestoranDesktop.Model;
using RestoranSDK;
using RestoranSDK.DTO;
using Unit = RestoranDesktop.Model.Unit;


namespace RestoranDesktop.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        #region Private Property
        private readonly ProductsAPI ProductsAPI;
        private string name { get; set; }
        private int unitID { get; set; }
        private int categoryID { get; set; }
        private string description { get; set; }
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Property

        public Unit UnitSelected { get; set; }


        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        public int UnitID
        {
            get { return this.unitID; }
            set
            {
                if (value != this.unitID)
                {
                    this.unitID = value;
                    NotifyPropertyChanged("UnitID");
                }
            }
        }
        public string Description
        {
            get { return this.description; }
            set
            {
                if (value != this.description)
                {
                    this.description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }
        public int CategoryId
        {
            get { return this.categoryID; }
            set
            {
                if (value != this.categoryID)
                {
                    this.categoryID = value;
                    NotifyPropertyChanged("CategoryID");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Create { get; set; }

        public ObservableCollection<Model.Product> Products { get; set; }
        public List<Model.Unit> Units { get; set; }
        #endregion

        #region Constructor

        public ProductViewModel()
        {
            Create = new Command(() =>
            {
                var dto = new ProductDTO();
                dto.Name = Name;
                dto.UnitId = UnitSelected.UnitId;
                dto.ProductCategoryId = CategoryId;
                dto.Description = Description;
                var result = ProductsAPI.Create(dto);
                if (result)
                {
                    MessageBox.Show("Продукт создан");
                }
            });
            ProductsAPI = new ProductsAPI();
            var products = ProductsAPI.Get();
            var productviewModel = products.Select(x => new Model.Product()
            {
                ProductId = x.Id,
                Name = x.Name,
                Description = x.Description,
                Unit = x.Unit,
                Category = x.ProductCategory,
                Detail = new Command(() =>
                {
                    DetailShow(x.Id);
                }
                     ),
                Delete = new Command(() =>
                {
                    Detele(x.Id);
                })
            });
            Products = new ObservableCollection<Model.Product>(productviewModel);

            Units = new List<Unit>() {
                new Unit()
            {
                UnitName="Кг",
                UnitId = 1
            } ,
            new Unit()
            {
                UnitName ="Л",
                UnitId =2
            } };
        }

        #endregion

        #region Private Methods
        private void DetailShow(int productId)
        {
            var productDetail = Products.Where(x => x.ProductId == productId).FirstOrDefault();
            var view = new View.Product();
            view.DataContext = productDetail;
            view.ShowDialog();
        }

        private void Detele(int productId)
        {
            var result = MessageBox.Show("Вы уверены", "Подтвердите удаление", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ProductsAPI.Delete(productId);
                Products.Remove(Products.Where(y => y.ProductId == productId).FirstOrDefault());
            }
        }
        #endregion

    }
}
