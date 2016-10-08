using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restoran
{
    // Базовый продукт
    public class Product  
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Введите название")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }  
        public int ProductCategoryId { get; set; }
        public virtual Unit Unit { get; set; } 
        public virtual ProductCategory ProductCategory { get; set; }    
        public virtual List<ProductOrdered> ProductsOrdered { get; set; }
        public virtual List<ProductSupplier> ProductsSupplier { get; set; }
        public virtual List<ProductStorage> ProductsStorage { get; set; }
    }
}
