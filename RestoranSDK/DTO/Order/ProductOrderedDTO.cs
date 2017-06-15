using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSDK.DTO
{
    public class ProductOrderedDTO
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
    }
}
