using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RestoranSDK;
using System.Collections.ObjectModel;
using System.Windows;
using Restoran;
using RestoranDesktop.Model;
using RestoranSDK.DTO;
using ProductRecipe = RestoranDesktop.Model.ProductRecipe;

namespace RestoranDesktop.ViewModel.Recipe
{
    public class RecipeEditViewModel : BaseViewModel
    {
        #region Private

        private string name;
        private string description;
        private int recipeId;
        private RecipeAPI recipeApi;
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


        public ObservableCollection<Model.ProductRecipe> Products { get; set; }
        public ObservableCollection<Model.ProductRecipe> ProductsRecipe { get; set; }
        public ObservableCollection<Model.Location> Locations { get; set; }
        public ObservableCollection<Model.Location> LocationsRecipe { get; set; }

        #endregion

        public RecipeEditViewModel(int recipeId)
        {
            this.recipeId = recipeId;
            recipeApi = new RecipeAPI();
            var recipeProduct = recipeApi.Get(this.recipeId);
            this.name = recipeProduct.Name;
            this.description = recipeProduct.Description;
            SaveCommand = new Command(Save);

            #region Продукты

            var productsRecipe = recipeProduct.Products.Select(x => new Model.ProductRecipe()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Value = x.Value,
                AddCommand = new Command((() => AddProduct(x.ProductId))),
                RemoveCommand = new Command((() => RemoveProduct(x.ProductId)))
            });
            ProductsRecipe = new ObservableCollection<ProductRecipe>(productsRecipe);

            var productsApi = new ProductsAPI();
            var products = productsApi.GetAll().Select(x => new ProductRecipe()
            {
                ProductId = x.Id,
                ProductName = x.Name,
                Value = 0,
                AddCommand = new Command((() => AddProduct(x.Id))),
                RemoveCommand = new Command((() => RemoveProduct(x.Id)))
            });

            Products = new ObservableCollection<ProductRecipe>();
            foreach (var product in products)
            {
                if (ProductsRecipe.All(p => p.ProductId != product.ProductId))
                {
                    Products.Add(product);
                }
            }
            #endregion

            #region Локации
            var recipeLocations = recipeApi.GetLocations(this.recipeId);
            var locationsRecipe = recipeLocations.Locations.Select(x => new Model.Location()
            {
                Id = x.Id,
                Name = x.Name,
                AddCommand = new Command((() => AddLocation(x.Id))),
                RemoveCommand = new Command((() => RemoveLocation(x.Id)))
            });
            LocationsRecipe = new ObservableCollection<Model.Location>(locationsRecipe);
            var locationApi = new LocationAPI();
            var locations = locationApi.GetAll().Select(x => new Model.Location()
            {
                Id = x.Id,
                Name = x.Name,
                AddCommand = new Command((() => AddLocation(x.Id))),
                RemoveCommand = new Command((() => RemoveLocation(x.Id)))
            });
            Locations = new ObservableCollection<Model.Location>();
            foreach (var location in locations)
            {
                if (LocationsRecipe.All(l => l.Id != location.Id))
                {
                    Locations.Add(location);
                }
            }
            #endregion
        }


        #region Private Method

        private void AddProduct(int productId)
        {
            var product = Products.Single(x => x.ProductId == productId);
            Products.Remove(product);
            ProductsRecipe.Add(product);
        }

        private void RemoveProduct(int productId)
        {
            var product = ProductsRecipe.Single(x => x.ProductId == productId);
            ProductsRecipe.Remove(product);
            Products.Add(product);
        }

        private void AddLocation(int locationId)
        {
            var location = Locations.Single(x => x.Id == locationId);
            Locations.Remove(location);
            LocationsRecipe.Add(location);

        }

        private void RemoveLocation(int locationId)
        {
            var location = LocationsRecipe.Single(x => x.Id == locationId);
            LocationsRecipe.Remove(location);
            Locations.Add(location);
        }

        private void Save()
        {
            var modelLocations = new RecipeLocationDTO()
            {
                Id = this.recipeId,
                Name = this.name,
                Description = this.description,
                Locations = LocationsRecipe.Select(x => new LocationDTO()
                {
                    Id = x.Id
                }).ToList()
            };
            var resultFlag = recipeApi.UpdateLocations(modelLocations);
            if (resultFlag)
            {
                var modelProducts = new RecipeDTO()
                {
                    Id = this.recipeId,
                    Name = this.name,
                    Description = this.description,
                    Products = ProductsRecipe.Select(x => new ProductRecipeDTO()
                    {
                        ProductId = x.ProductId,
                        Value = x.Value
                    }).ToList()
                };
               resultFlag=recipeApi.UpdateProducts(modelProducts);
                if (resultFlag)
                {
                    MessageBox.Show("Успешно сохранено");
                }
                if (!resultFlag)
                {
                    MessageBox.Show("Ошибка при сохранении");
                }

            }
            if (!resultFlag)
            {
                MessageBox.Show("Ошибка при сохранении");
            }
        }
        #endregion
    }
}
