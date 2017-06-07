using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestoranDesktop.Model;
using RestoranSDK;
using RestoranSDK.DTO;

namespace RestoranDesktop.ViewModel
{
    public class ProductCreateViewModel : INotifyPropertyChanged
    {
        #region Private
        private string name { get; set; }
        private string description { get; set; }
        private readonly UnitAPI unitAPI;
        private readonly ProductCategoryAPI productCategoryAPI;
        private readonly ProductsAPI productsAPI;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Property
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get { return this.description; }
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }
        public Unit SelectedUnit { get; set; }
        public ProductCategory SelectProductCategory { get; set; }
        #endregion
        public List<Unit> Units { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public ICommand Create { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructor

        public ProductCreateViewModel()
        {
            unitAPI=new UnitAPI();
            productCategoryAPI = new ProductCategoryAPI();
            productsAPI = new ProductsAPI();
            Units = unitAPI.GetAll().Select(x => new Unit()
            {
                UnitName =x.Symbol,
                UnitId =x.Id
            }).ToList();
            ProductCategories = productCategoryAPI.GetAll().Select(x => new ProductCategory()
            {
                Name =x.Name,
                Id =x.Id
            }).ToList();
            Create=new Command(() =>
            {
                var model=new ProductDTO();
                model.Name = this.name;
                model.Description = this.description;
                model.UnitId = SelectedUnit.UnitId;
                model.ProductCategoryId = SelectProductCategory.Id;
                var resultFlag = productsAPI.Create(model);
                if (resultFlag)
                {
                    MessageBox.Show("Продукт успешно создан");
                }
                if (!resultFlag)
                {
                    MessageBox.Show("Во время создания произошла ошибка");
                }
            });
        }

        #endregion

    }
}



