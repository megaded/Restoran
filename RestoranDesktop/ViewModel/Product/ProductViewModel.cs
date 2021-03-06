﻿using System;
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
using RestoranDesktop.View;
using RestoranDesktop.View.Product;
using RestoranSDK;
using RestoranSDK.DTO;
using Unit = RestoranDesktop.Model.Unit;


namespace RestoranDesktop.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        /// <summary>
        /// View model представления продуктов.
        /// </summary>
        #region Private Property
        private readonly ProductsAPI ProductsAPI;
        private readonly UnitAPI UnitAPI;
        private readonly ProductCategoryAPI ProductCategoryAPI;
        private string name { get; set; }
        private int unitID { get; set; }
        private int categoryID { get; set; }
        private string description { get; set; }
       
        #endregion

        #region Property

        public Model.Unit UnitSelected { get; set; }

        public Model.ProductCategory ProductCategorySelected { get; set; }

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
        
        public ICommand Create { get; set; }

        public ObservableCollection<Model.Product> Products { get; set; }
        public List<Model.Unit> Units { get; set; }
        public List<Model.ProductCategory> ProductCategory { get; set; }
        #endregion

        #region Constructor
        public ProductViewModel()
        {
            ProductsAPI = new ProductsAPI();
            UnitAPI = new UnitAPI();
            ProductCategoryAPI = new ProductCategoryAPI();
            var products = ProductsAPI.GetAll();
            var productviewModel = products.Select(x => new Model.Product()
            {
                ProductId = x.Id,
                Name = x.Name,
                Description = x.Description,
                UnitId = x.UnitId,
                Unit = x.Unit,
                CategoryId = x.ProductCategoryId,
                Category = x.ProductCategory,
                Detail = new Command(() =>
                {
                    DetailShow(x.Id);
                }
                     ),
                Delete = new Command(() =>
                {
                    Detele(x.Id);
                }),
                Edit = new Command(() =>
                {
                    Edit(x.Id);
                })
            });
            Products = new ObservableCollection<Model.Product>(productviewModel);

        }

        #endregion

        #region Private Methods


        private void DetailShow(int productId)
        {
            var productDetail = Products.Single(x => x.ProductId == productId);
            var view = new ProductDetailView()
            {
                DataContext = productDetail
            };
            view.ShowDialog();
        }

        private void Edit(int productId)
        {
            var view = new ProductEditView();
            var entity = Products.Single(x => x.ProductId == productId);
            var viewModel = new ProductEditViewModel(entity);
            view.DataContext = viewModel;
            view.ShowDialog();
        }
        private void Detele(int productId)
        {
            var result = MessageBox.Show("Вы уверены", "Подтвердите удаление", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ProductsAPI.Delete(productId);
                Products.Remove(Products.Single(y => y.ProductId == productId));
            }
        }
        #endregion

    }
}
