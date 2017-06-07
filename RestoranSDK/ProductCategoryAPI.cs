using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using RestoranSDK.DTO;
using System.Net;
using Newtonsoft.Json;

namespace RestoranSDK
{
    public class ProductCategoryAPI
    {
        private readonly string url = @"http://localhost:51155";
        /// <summary>
        /// Получение всех категорий продуктов
        /// </summary>
        /// <returns></returns>
        public List<ProductCategoryDTO> GetAll()
        {
            var result = new List<ProductCategoryDTO>();
            var url = new Uri($"{this.url}/category/categories");
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                var reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<ProductCategoryDTO>>(json);
            }
            return result;
        }
    }
}
