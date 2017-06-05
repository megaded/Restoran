using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoranDesktop.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Category { get; set; }
        public ICommand Detail { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }

    }
}
