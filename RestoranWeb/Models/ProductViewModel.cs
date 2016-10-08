using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran;
using System.Web.Mvc;

namespace RestoranWeb.Models
{
  public  class ProductViewModel
    {
        public Product Product { get; set; }
        public SelectList Units { get; set; }
        public SelectList ProductСategories { get; set; }
        public int UnitId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
