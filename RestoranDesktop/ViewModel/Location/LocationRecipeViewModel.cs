using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranSDK;

namespace RestoranDesktop.ViewModel.Location
{
    public class LocationRecipeViewModel
    {
        private LocationAPI locationAPI;
        private int locatioId;
        public ObservableCollection<Model.Recipe> Recipes { get; set; }
        public LocationRecipeViewModel(int locationId)
        {
            this.locatioId = locationId;
            locationAPI =new LocationAPI();
            var recipes = locationAPI.GetRecipes(locationId).Select(x=>new Model.Recipe()
            {
                Name = x.Name,
                Id = x.Id
            });
            Recipes=new ObservableCollection<Model.Recipe>(recipes);
        }

    }
}
