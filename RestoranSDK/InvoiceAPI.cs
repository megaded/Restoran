using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestoranSDK.DTO.Invoice;

namespace RestoranSDK
{
    public class InvoiceAPI
    {
        private readonly string url = @"http://localhost:51155";

        /// <summary>
        /// Получение информации о накладной
        /// </summary>
        /// <param name="invoiceId">Id накладной</param>
        /// <returns></returns>
        public InvoiceDTO Get(int invoiceId)
        {
            var model=new InvoiceDTO();
            var url=new Uri($"{this.url}/invoice/{invoiceId}");
            var request = WebRequest.Create(url);
            request.Method = "Get";
            var response = request.GetResponse();
            using (var stream=new StreamReader(response.GetResponseStream()))
            {
                var json = stream.ReadToEnd();
                model = JsonConvert.DeserializeObject<InvoiceDTO>(json);
            }
            return model;
        }

    }
}
