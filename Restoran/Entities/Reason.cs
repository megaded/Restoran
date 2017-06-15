using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Причина списания продукта
    /// </summary>
    public class Reason
    {
        public int ReasonId { get; set; }
        public string Name { get; set; }
        public virtual ICollection< ProductDisposal> ProductDisposal { get; set; }
        public Reason()
        {
            ProductDisposal = new List<ProductDisposal>();
        }
    }
}
