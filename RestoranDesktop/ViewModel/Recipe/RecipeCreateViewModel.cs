using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using RestoranDesktop.Model;
using RestoranSDK;
using RestoranSDK.DTO;

namespace RestoranDesktop.ViewModel.Recipe
{
    public class RecipeCreateViewModel : BaseViewModel
    {
        #region Private
        private ProductsAPI productApi;
        private LocationAPI locationApi;
        private RecipeAPI recipeApi;
        private string name;
        private string description;
        
        #endregion

        #region Property
        public ObservableCollection<Model.ProductRecipe> Products { get; set; }
        public ObservableCollection<Model.ProductRecipe> ProductsRecipe { get; set; }
        public ObservableCollection<Model.Location> Locations { get; set; }
        public ObservableCollection<Model.Location> LocationsRecipe { get; set; }
        public ICommand SaveCommand { get; set; }
       
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

        public RecipeCreateViewModel()
        {
            productApi = new ProductsAPI();
            var products = productApi.GetAll().Select(x => new ProductRecipe()
            {
                ProductId = x.Id,
                ProductName = x.Name,
                Value = 0,
                AddCommand = new Command((() =>
                {
                    AddProduct(x.Id);
                })),
                RemoveCommand = new Command((() =>
                {
                    RemoveProduct(x.Id);
                }))
            });
            Products = new ObservableCollection<ProductRecipe>(products);
            ProductsRecipe = new ObservableCollection<ProductRecipe>();
            locationApi = new LocationAPI();
            var locations = locationApi.GetAll().Select(x => new Model.Location()
            {
                Id = x.Id,
                Name = x.Name,
                AddCommand = new Command(() =>
                {
                    AddLocation(x.Id);
                }),
                RemoveCommand = new Command((() =>
                {
                    RemoveLocation(x.Id);
                }))
            });
            Locations = new ObservableCollection<Model.Location>(locations);
            LocationsRecipe = new ObservableCollection<Model.Location>();
            SaveCommand = new Command((() =>
              {
                  this.Save();
              }));
        }

        private void AddProduct(int productId)
        {
            var product = Products.Single(x => x.ProductId == productId);
            if (product != null)
            {
                Products.Remove(product);
                ProductsRecipe.Add(product);
            }
        }

        private void RemoveProduct(int productId)
        {
            var product = ProductsRecipe.Single(x => x.ProductId == productId);
            if (product != null)
            {
                ProductsRecipe.Remove(product);
                Products.Add(product);
            }
        }

        private void AddLocation(int locationId)
        {
            var location = Locations.Single(x => x.Id == locationId);
            if (location != null)
            {
                Locations.Remove(location);
                LocationsRecipe.Add(location);
            }
        }

        private void RemoveLocation(int locationId)
        {
            var location = LocationsRecipe.Single(x => x.Id == locationId);
            if (location != null)
            {
                LocationsRecipe.Remove(location);
                Locations.Add(location);
            }
        }

        private void Save()
        {
            var recipe = new RecipeDTO();
            recipeApi = new RecipeAPI();
            recipe.Name = this.name;
            recipe.Description = this.description;
            recipe.Products = ProductsRecipe.Select(x => new ProductRecipeDTO()
            {
                ProductId = x.ProductId,
                Value = x.Value
            }).ToList();
            var newRecipe = recipeApi.Create(recipe);
            var recipeLocation = new RecipeLocationDTO();
            recipeLocation.Id = newRecipe.Id;
            recipeLocation.Locations = LocationsRecipe.Select(x => new LocationDTO()
            {
                Id = x.Id
            }).ToList();
            var flagResult = recipeApi.UpdateLocations(recipeLocation);
            if (flagResult)
            {
                MessageBox.Show("Рецепт создан");
            }
            if (!flagResult)
            {
                MessageBox.Show("Ошибка при создании");
            }
        }
    }
}
