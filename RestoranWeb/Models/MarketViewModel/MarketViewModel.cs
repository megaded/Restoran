using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoranWeb.Models.MarketViewModel
{
    public class MarketViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [StringLength(15, ErrorMessage = "Не более 15 символов")]
        public string Name { get; set; }
        public MarketViewModel()
        {

        }
    }
}