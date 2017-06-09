using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDesktop.Model
{
    public class ProductStorage
    {
        public int ProductStorageId { get; set; }
        public double Value { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalQuantity { get; set; }
        public int ProductId { get; set; }
        public  string ProductName { get; set; }
    }
}
