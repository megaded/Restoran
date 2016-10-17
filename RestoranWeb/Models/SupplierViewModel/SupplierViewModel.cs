using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoranWeb.Models.SupplierViewModel
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [StringLength(15, ErrorMessage = "Не более 15 символов")]
        public string Name { get; set; }
        public SupplierViewModel()
        {

        }
    }
}