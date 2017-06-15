using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSDK.DTO
{
    public class OrderDetailDTO
    {
        public int LocationId { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime AcceptDate { get; set; }
        public bool Accept { get; set; }
        public List<ProductOrderedDTO> Products { get; set; }
    }
}
