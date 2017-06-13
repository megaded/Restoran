using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RestoranSDK;
using System.Collections.ObjectModel;
using Restoran;
using RestoranDesktop.Model;
using ProductRecipe = RestoranDesktop.Model.ProductRecipe;

namespace RestoranDesktop.ViewModel.Recipe
{
    public class RecipeEditViewModel:BaseViewModel
    {
        #region Private

        private string name;
        private string description;
        private int id;

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

        public ICommand SaveCommand { get; set; }

        private RecipeAPI recipeApi;
        private ProductsAPI productsApi;
        public ObservableCollection<Model.ProductRecipe> Products { get; set; }
        public ObservableCollection<Model.ProductRecipe> ProductsRecipe { get; set; }
        public ObservableCollection<Model.Location> Locations { get; set; }
        public ObservableCollection<Model.Location>LocationsRecipe { get; set; }

        #endregion

        public RecipeEditViewModel(int recipeId)
        {
            recipeApi=new RecipeAPI();
            var recipeProducts = recipeApi.Get(recipeId);
            var productsRecipe = recipeProducts.Products.Select(x => new Model.ProductRecipe()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName                
            });
            ProductsRecipe=new ObservableCollection<ProductRecipe>(productsRecipe);

            productsApi=new ProductsAPI();
            var products = productsApi.GetAll().Select(x => new ProductRecipe()
            {
                ProductId = x.Id,
                ProductName = x.Name
            });

            Products = new ObservableCollection<ProductRecipe>();
            foreach (var product in products)
            {
                if (ProductsRecipe.All(p => p.ProductId != product.ProductId))
                {
                    Products.Add(product);
                }
            }
        }
    }
}
