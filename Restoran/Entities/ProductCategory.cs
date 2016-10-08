using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
   public class ProductCategory
    {

        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
      
    }
}
