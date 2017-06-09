using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoranDesktop.Model
{
   public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICommand OpenCommand { get; set; }
    }
}
