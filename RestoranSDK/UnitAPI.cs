using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestoranSDK.DTO;

namespace RestoranSDK
{
    public class UnitAPI
    {
        private readonly string url = @"http://localhost:51155";

        /// <summary>
        /// Получение всех единиц измерения
        /// </summary>
        /// <returns></returns>
        public List<UnitDTO> GetAll()
        {

            var result = new List<UnitDTO>();
            var url = new Uri($"{this.url}/unit/units");
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                var reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<UnitDTO>>(json);
            }
            return result;
        }

        /// <summary>
        /// Создает новую единицу измерения
        /// </summary>
        /// <param name="model">Модель единицы измерения</param>
        /// <returns></returns>
        public bool Create(UnitDTO model)
        {
            var url = new Uri($"{this.url}/unit/create");
            var json = JsonConvert.SerializeObject(model);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(json);
                dataStream.Close();

            }
            var responce = (HttpWebResponse)request.GetResponse();
            return responce.StatusCode == HttpStatusCode.Created ? true : false;

        }

        /// <summary>
        /// Удаляет единицу измерения по ID
        /// </summary>
        /// <param name="unitId">Id единицы измерения</param>
        /// <returns></returns>
        public bool Delete(int unitId)
        {
            var url = new Uri($"{this.url}/unit/delete/{unitId}");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Delete";
            var responce = (HttpWebResponse)request.GetResponse();
            return responce.StatusCode == HttpStatusCode.OK ? true : false;
        }

        public bool Update(UnitDTO unit)
        {
            var json = JsonConvert.SerializeObject(unit);
            var url = new Uri($"{this.url}/unit/update");
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
    }
}
