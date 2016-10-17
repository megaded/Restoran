using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RestoranWeb.Models
{
  public  class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [StringLength(15, ErrorMessage = "Не более 15 символов")]
        public string Name { get; set; }
        public string Description { get; set; }
        public SelectList Units { get; set; }
        public SelectList ProductСategories { get; set; }
        public int UnitId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
