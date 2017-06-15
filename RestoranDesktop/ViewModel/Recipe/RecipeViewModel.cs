using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RestoranDesktop.Model;
using RestoranDesktop.View.Recipe;
using RestoranSDK;

namespace RestoranDesktop.ViewModel.Recipe
{
    public class RecipeViewModel
    {
        private RecipeAPI recipeAPI;
        public ObservableCollection<Model.Recipe> Recipes { get; set; }        
        public ICommand CreateCommand { get; set; }
        public RecipeViewModel()
        {
            recipeAPI = new RecipeAPI();
            var recipes = recipeAPI.GetAll().Select(x => new Model.Recipe()
            {
                Id = x.Id,
                Name = x.Name,
                Description=x.Description,
                Detail = new Command((() =>
                {
                    this.Detail(x.Id);
                })),
                Edit =new Command((() =>
                {
                    this.Edit(x.Id);
                })),
                Delete = new Command((() =>
                {
                    this.Delete();
                }))
            });
            Recipes = new ObservableCollection<Model.Recipe>(recipes);
            
        }

        private void Detail(int recipeId)
        {
            var view=new RecipeDetailView();
            var viewmodel=new RecipeDetailViewModel(recipeId);
            view.DataContext = viewmodel;
            view.Show();
        }

        private void Edit(int recipeId)
        {
            var view=new RecipeEditView();
            var viewmodel=new RecipeEditViewModel(recipeId);
            view.DataContext = viewmodel;
            view.Show();
        }

        private void Delete()
        {
            
        }

        private void Create()
        {
            
        }
    }
}
