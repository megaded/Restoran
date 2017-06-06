using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSDK.DTO
{
  public  class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }
    }
}
