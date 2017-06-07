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
  public  class UnitAPI
    {
        private readonly string url = @"http://localhost:51155";
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

     /*   public bool Create()
        {
            
        }

        public Delete()
        {
            
        } */
    }
}
