using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranSDK.DTO;

namespace RestoranSDK
{
    public class RecipeAPI
    {
        private readonly string url = @"http://localhost:51155";

        public List<RecipeDTO> GetAll()
        {
            var result=new List<RecipeDTO>();
            Uri url=new Uri($"{this.url}/recipe/recipes");
            return result;
        } 
    }
}
