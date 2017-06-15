using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSDK.DTO.Invoice
{
   public class InvoiceProductDTO
    {
        public int InvoiceId { get; set; }
        public List<InvoiceProductDTO> Products { get; set; }
    }
}
