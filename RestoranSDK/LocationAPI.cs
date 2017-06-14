using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            var url = new Uri($"{this.url}/location/locations");
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
        public List<ProductStorageDTO> GetProduct(int locationId)
        {
            var result = new List<ProductStorageDTO>();
            var url = new Uri($"{this.url}/location/{locationId}/products");
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
        public List<RecipeDTO> GetRecipes(int locationId)
        {
            var result = new List<RecipeDTO>();
            var url = new Uri($"{this.url}/location/{locationId}/recipes");
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
        public List<SupplierDTO> GetSupplier(int locationId)
        {
            var result = new List<SupplierDTO>();
            var url = new Uri($"{this.url}/location/{locationId}/supplier");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<SupplierDTO>>(json);
            }
            return result;
        }

        /// <summary>
        /// Получение списка продуктов поставщика для локации
        /// </summary>
        /// <param name="locationId">Id локации</param>
        /// <param name="supplierId">Id поставщика</param>
        /// <returns></returns>        
        public List<ProductSupplierDTO> GetProductSupplier(int locationId, int supplierId)
        {
            var model = new List<ProductSupplierDTO>();
            var url = new Uri($"{this.url}/location/{locationId}/supplier/{supplierId}/products");
            var request = WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                model = JsonConvert.DeserializeObject<List<ProductSupplierDTO>>(json);
            }
            return model;
        }

        /// <summary>
        /// Получение списка заказов локации
        /// </summary>
        /// <param name="locationId">Id локации</param>
        /// <returns></returns>
        public List<OrderDTO> GetOrders(int locationId)
        {
            var model = new List<OrderDTO>();
            var url=new Uri($"{this.url}/location/{locationId}/orders");
            var request = WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream=new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                model = JsonConvert.DeserializeObject<List<OrderDTO>>(json);
            }
            return model;
        }
    }
}
