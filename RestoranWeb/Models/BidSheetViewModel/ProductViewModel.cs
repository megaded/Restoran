using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestoranWeb.Models.BidSheetViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Цена должны быть больше 0")]
        public decimal Price { get; set; }
        public string Unit { get; set; }
    }
}