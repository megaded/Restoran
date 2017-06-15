using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Списание продуктов
    /// </summary>
    public class ProductDisposal
    {
        public int ProductDisposalId { get; set; }
        public int ReasonId { get; set; }
        public Reason Reason { get; set; }
        public List<DisposalProduct> Products { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        public ProductDisposal()
        {
            Products = new List<DisposalProduct>();
        }
    }
}
