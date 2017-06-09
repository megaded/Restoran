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

        /// <summary>
        /// Получение категории продукта по Id
        /// </summary>
        /// <param name="productCategoryId">Id категории продукта</param>
        /// <returns></returns>
        public ProductCategoryDTO Get(int productCategoryId)
        {
            var result = new ProductCategoryDTO();
            var url = new Uri($"{this.url}/category/{productCategoryId}");
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                var reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<ProductCategoryDTO>(json);
            }
            return result;
        }

        /// <summary>
        /// Создание категории продукта
        /// </summary>
        /// <param name="model">Модель категории продукта</param>
        /// <returns></returns>
        public bool Create(ProductCategoryDTO model)
        {
            var url = new Uri($"{this.url}/category/create");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType= "application/json";
            var json = JsonConvert.SerializeObject(model);
            using (var stream=new StreamWriter(request.GetRequestStream()))
            {
                stream.Write(json);
                stream.Close();                
            }          
            var response =(HttpWebResponse) request.GetResponse();
            return response.StatusCode == HttpStatusCode.OK ? true : false;
        }

        /// <summary>
        /// Обновление информации о категории продукта
        /// </summary>
        /// <param name="model">Модель категории продукта</param>
        /// <returns></returns>
        public bool Update(ProductCategoryDTO model)
        {
            var url = new Uri($"{this.url}/category/update");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(model);
            using (var stream = new StreamWriter(request.GetRequestStream()))
            {
                stream.Write(json);
                stream.Close();
            }
            var response = (HttpWebResponse)request.GetResponse();
            return response.StatusCode == HttpStatusCode.OK ? true : false;
        }

        /// <summary>
        /// Удаление категории продукта по Id
        /// </summary>
        /// <param name="productCategoryId">Id категории продукта</param>
        /// <returns></returns>
        public bool Delete(int productCategoryId)
        {
            var url = new Uri($"{this.url}/category/delete/{productCategoryId}");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Delete";                     
            var response = (HttpWebResponse)request.GetResponse();
            return response.StatusCode == HttpStatusCode.OK ? true : false;
        }
    }
}
