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
    public class OrderAPI
    {
        private readonly string url = @"http://localhost:51155";

        /// <summary>
        /// Получение информации о заказе
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <returns></returns>
        public OrderDetailDTO Get(int orderId)
        {
            var model = new OrderDetailDTO();
            var url = new Uri($"{this.url}/order/{orderId}");
            var request = WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                model = JsonConvert.DeserializeObject<OrderDetailDTO>(json);
            }
            return model;
        }

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        public List<OrderDTO> GetAll()
        {
            var model = new List<OrderDTO>();
            var url = new Uri($"{this.url}/order");
            var request = WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                model = JsonConvert.DeserializeObject<List<OrderDTO>>(json);
            }
            return model;
        }

        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <param name="model">Модель заказа</param>
        /// <returns></returns>
        public bool Create(OrderDetailDTO model)
        {
            var url = new Uri($"{this.url}/order");
            var json = JsonConvert.SerializeObject(model);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Post";
            request.ContentType = "application/json";
            using (var stream = new StreamWriter(request.GetRequestStream()))
            {
                stream.Write(json);
                stream.Close();
            }
            var response = (HttpWebResponse)request.GetResponse();
            return response.StatusCode == HttpStatusCode.OK ? true : false;
        }

        //Todo Доделать апи заказов
    }
}
