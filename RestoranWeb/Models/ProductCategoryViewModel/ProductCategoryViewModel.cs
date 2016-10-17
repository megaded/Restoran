using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestoranWeb.Models.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите название")]
        [StringLength(15,ErrorMessage ="Не более 15 символов")]
        public string Name { get; set; }
        public ProductCategoryViewModel()
        {

        }
    }
}