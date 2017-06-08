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
    public class ProductEditViewModel : INotifyPropertyChanged
    {
        #region Private
        private int id { get; set; }
        private string name { get; set; }
        private string description { get; set; }
        private readonly UnitAPI UnitAPI;
        private readonly ProductCategoryAPI ProductCategoryAPI;

        #endregion

        #region Property
        public Model.Unit SelectedUnit { get; set; }
        public ProductCategory SelectedCategory { get; set; }
        public List<Model.Unit> Units { get; set; }

        public List<Model.ProductCategory> ProductCategory { get; set; }
        public ICommand Update { get; set; }

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

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Constructor

        public ProductEditViewModel(Product product)
        {
            UnitAPI = new UnitAPI();
            ProductCategoryAPI = new ProductCategoryAPI();
            this.id = product.ProductId;
            this.name = product.Name;
            this.description = product.Description;
            this.Units = UnitAPI.GetAll().Select(x => new Model.Unit()
            {
                UnitId = x.Id,
                Name = x.Name
            }).ToList();
            this.SelectedUnit = Units.Single(x => x.UnitId == product.UnitId);
            this.ProductCategory = ProductCategoryAPI.GetAll().Select(x => new ProductCategory()
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
            this.SelectedCategory = ProductCategory.Single(x => x.Id == product.CategoryId);
            Update = new Command(() =>
             {
                 ProductsAPI productAPI = new ProductsAPI();
                 var productDTO = new ProductDTO();
                 productDTO.Name = Name;
                 productDTO.Description = Description;
                 productDTO.Id = id;
                 productDTO.UnitId = SelectedUnit.UnitId;
                 productDTO.ProductCategoryId = SelectedCategory.Id;
                 var resultFlag = productAPI.Update(productDTO);
                 if (resultFlag)
                 {
                     MessageBox.Show("Успешно сохранено.");
                 }
                 if(!resultFlag)
                 {
                     MessageBox.Show("Во время сохранения произошла ошибка.");
                 }
             });
        }


        #endregion
    }
}
