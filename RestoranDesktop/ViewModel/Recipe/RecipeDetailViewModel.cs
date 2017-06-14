using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Restoran;
using RestoranDesktop.Model;
using RestoranDesktop.View.Recipe;
using RestoranSDK;
using ProductRecipe = RestoranDesktop.Model.ProductRecipe;

namespace RestoranDesktop.ViewModel.Recipe
{
    public class RecipeDetailViewModel:BaseViewModel
    {
        private RecipeAPI recipeApi;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICommand EditCommand { get; set; }

        public ObservableCollection<ProductRecipe> Products { get; set; }

        public ObservableCollection<Model.Location> Locations { get; set; }

        public RecipeDetailViewModel(int recipeId)
        {
            recipeApi = new RecipeAPI();
            var recipe = recipeApi.Get(recipeId);
            this.Id = recipe.Id;
            this.Name = recipe.Name;
            this.Description = recipe.Description;
            var products = recipe.Products.Select(x => new ProductRecipe()
            {
                ProductName = x.ProductName,
                Value = x.Value
            });
            Products=new ObservableCollection<ProductRecipe>(products);
            var recipeLocation = recipeApi.GetLocations(recipeId);
            var locations = recipeLocation.Locations.Select(x=>new Model.Location()
            {
                Name = x.Name
            });
           Locations=new ObservableCollection<Model.Location>(locations);
            EditCommand=new Command((() =>
            {
                
            }));
        }

        private void Edit(int recipeId)
        {
            var view=new RecipeEditView();
            
        }
    }
}
