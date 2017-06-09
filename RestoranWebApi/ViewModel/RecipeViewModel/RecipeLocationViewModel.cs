using System.Collections.Generic;

namespace RestoranApi.ViewModel.RecipeViewModel
{
    public class RecipeLocationViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<LocationViewModel.LocationViewModel> Location { get; set; }
    }
}