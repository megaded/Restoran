using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Не помню что это
    /// </summary>
  public  class Operation
    {
        public int OperationId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}
