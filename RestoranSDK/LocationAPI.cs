using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestoranSDK.DTO;

namespace RestoranSDK
{
    public class LocationAPI
    {
        private readonly string url = @"http://localhost:51155";

        /// <summary>
        /// Получение списка всех локаций.
        /// </summary>
        /// <returns></returns>
        public List<LocationDTO> GetAll()
        {
            var result = new List<LocationDTO>();
            Uri url = new Uri($"{this.url}/location/locations");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<LocationDTO>>(json);
            }
            return result;
        }

        /// <summary>
        /// Получение списка продуктов локации.
        /// </summary>
        /// <param name="locationId">Id локации.</param>
        /// <returns></returns>
        public List<ProductStorageDTO> GetLocationProduct(int locationId)
        {
            var result = new List<ProductStorageDTO>();
            Uri url = new Uri($"{this.url}/location/{locationId}/products");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<ProductStorageDTO>>(json);
            }
            return result;
        }

        /// <summary>
        /// Получение списка рецептов локации.
        /// </summary>
        /// <param name="locationId">Id локации</param>
        /// <returns></returns>
        public List<RecipeDTO> GetLocationRecipes(int locationId)
        {
            var result = new List<RecipeDTO>();
            Uri url = new Uri($"{this.url}/{locationId}/recipes");
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = request.GetResponse();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<RecipeDTO>>(json);
            }
            return result;
        }

        /// <summary>
        /// Получение списка поставщиков локации.
        /// </summary>
        /// <param name="locationId">Id локации</param>
        /// <returns></returns>
        public List<SupplierDTO> GetLocationSupplier(int locationId)
        {
            var result=new List<SupplierDTO>();
            Uri url=new Uri($"{this.url}/{locationId}/supplier");
            var request =(HttpWebRequest) WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream=new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<SupplierDTO>>(json);
            }
            return result;
        }
    }
}
