using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestoranWeb.Models.UnitViewModel
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите название")]
        [StringLength(15,ErrorMessage ="Не больше 15 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите сокращение")]
        [StringLength(3, ErrorMessage = "Не больше трех символов")]
        public string Symbol { get; set; }
        public UnitViewModel()
        {

        }
    }
}