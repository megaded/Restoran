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
    public class ProductsAPI
    {
        private readonly string url = @"http://localhost:51155";
        
        /// <summary>
        /// Запрос на получение все продуктов
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> GetAll()
        {
            var result = new List<ProductDTO>();
            var url = new Uri($"{this.url}/product/products");
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                var reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<ProductDTO>>(json);
            }
            return result;
        }

        /// <summary>
        /// Получение продукта по ID
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        public ProductDTO Get(int productId)
        {
            var result = new ProductDTO();
            var url = new Uri($"{this.url}/product/{productId}");
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                var reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<ProductDTO>(json);
            }
            return result;              
        }

        /// <summary>
        /// Запрос на создание нового продукта.
        /// </summary>
        /// <param name="product">Модель продукта</param>
        /// <returns></returns>
        public bool Create(ProductDTO product)
        {
            var json = JsonConvert.SerializeObject(product);
            var byteContent = Encoding.UTF8.GetBytes(json);
            var url = new Uri(@"http://localhost:51155/product/create");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(json);
                dataStream.Close();

            }
            var responce = (HttpWebResponse)request.GetResponse();
            if (responce.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Обновление информации о продукте
        /// </summary>
        /// <param name="product">Модель продукта</param>
        /// <returns></returns>
        public bool Update(ProductDTO product)
        {
            var json = JsonConvert.SerializeObject(product);
            var byteContent = Encoding.UTF8.GetBytes(json);
            var url = new Uri($"{this.url}/product/update");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(json);
                dataStream.Close();

            }
            var responce = (HttpWebResponse)request.GetResponse();
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Запрос на удаление продукта
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        public bool Delete(int productId)
        {
            var urlString = string.Format($"http://localhost:51155/product/delete/{productId}");
            var url = new Uri(urlString);
            var request = WebRequest.Create(url);
            request.Method = "Delete";
            var response =(HttpWebResponse) request.GetResponse();           
            return response.StatusCode == HttpStatusCode.OK?true:false;
        }
    }
}
