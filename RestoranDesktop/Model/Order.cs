using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDesktop.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string SupplierName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime AcceptDate { get; set; }
        public bool Accept { get; set; }
    }
}
