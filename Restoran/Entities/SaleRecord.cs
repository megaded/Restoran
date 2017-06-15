using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Данные о продажи блюд
    /// </summary>
   public class SaleRecord
    {
        public int SaleRecordId { get; set; }
        public Recipe Recipes { get; set; }
        public int Count { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime DateSale { get; set; }
    }
}
