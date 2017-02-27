using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
   public class Transfer
    {
        public int TransferId { get; set; }
        public DateTime Date { get; set; }
        public bool Accept { get; set; }
        public ICollection<ProductTransfer> Products { get; set; }
        public int FromId { get; set; }
        public virtual Location From { get; set; }     
        public int ToId { get; set; }
        public virtual Location To { get; set; }   
        public Transfer()
        {
            Products = new List<ProductTransfer>();
        }
    }
}
