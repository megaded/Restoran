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
    public class RecipeAPI
    {
        private readonly string url = @"http://localhost:51155";

        /// <summary>
        /// Получение всех рецептов
        /// </summary>
        /// <returns></returns>
        public List<RecipeDTO> GetAll()
        {
            var result=new List<RecipeDTO>();
            Uri url=new Uri($"{this.url}/recipe/recipes");
            var request =(HttpWebRequest) WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream=new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                result=JsonConvert.DeserializeObject<List<RecipeDTO>>(json);
            }
            return result;
        }

        /// <summary>
        /// Получение рецепта по Id
        /// </summary>
        /// <param name="recipeId">Id рецепта</param>
        /// <returns></returns>
        public RecipeDTO Get(int recipeId)
        {
            var result=new RecipeDTO();
            Uri url=new Uri($"{this.url}/recipe/{recipeId}");
            var request =(HttpWebRequest) WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream=new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                result = JsonConvert.DeserializeObject<RecipeDTO>(json);
            }
            return result;
        }

        /// <summary>
        /// Получение списка локаций рецепта
        /// </summary>
        /// <param name="recipeId">Id рецепта</param>
        /// <returns></returns>
        public RecipeLocationDTO GetLocations(int recipeId)
        {
            var result=new RecipeLocationDTO();
            Uri url=new Uri($"{this.url}/recipe/locations/{recipeId}");
            var request = WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream=new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                result = JsonConvert.DeserializeObject<RecipeLocationDTO>(json);
            }
            return result;
        }

        /// <summary>
        /// Создание нового рецепта
        /// </summary>
        /// <param name="model">Модель рецепта</param>
        /// <returns></returns>
        public RecipeDTO Create(RecipeDTO model)
        {
            var result=new RecipeDTO();
            var json = JsonConvert.SerializeObject(model);
            Uri url=new Uri($"{this.url}/recipe/create");
            var request =(HttpWebRequest) WebRequest.Create(url);
            request.Method = "Post";
            request.ContentType = "application/json";
            using (var stream=new StreamWriter(request.GetRequestStream()))
            {
                stream.Write(json);
                stream.Close();
            }
            var response = request.GetResponse();
            using (var stream=new StreamReader(response.GetResponseStream()))
            {
                 json = stream.ReadToEnd();
                result = JsonConvert.DeserializeObject<RecipeDTO>(json);
            }
            return result;
        }


        /// <summary>
        /// Обновление локаций рецепта
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        public bool UpdateLocations(RecipeLocationDTO model)
        {
            var json = JsonConvert.SerializeObject(model);
            Uri url=new Uri($"{this.url}/recipe/locations");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Post";
            request.ContentType = "application/json";
            using (var stream=new StreamWriter(request.GetRequestStream()))
            {
                stream.Write(json);
                stream.Close();
            }
            var response =(HttpWebResponse) request.GetResponse();
            return response.StatusCode == HttpStatusCode.OK ? true : false;
        }

        /// <summary>
        /// Обновление информации и продуктах рецепта
        /// </summary>
        /// <param name="model">Модель рецепта</param>
        /// <returns></returns>
        public bool UpdateProducts(RecipeDTO model)
        {
            var json = JsonConvert.SerializeObject(model);
            Uri url=new Uri($"{this.url}/recipe/product");
            var request =(HttpWebRequest) WebRequest.Create(url);
            request.Method = "Post";
            request.ContentType= "application/json";
            using (var stream=new StreamWriter(request.GetRequestStream()))
            {
                stream.Write(json);
                stream.Close();
            }
            var response =(HttpWebResponse) request.GetResponse();
            return response.StatusCode == HttpStatusCode.OK ? true : false;
        }

    }
}
