using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoranDesktop.Model
{
 public class Unit
    {
        public  string Name { get; set; }
        public string Symbol { get; set; }
        public int UnitId { get; set; }
        public ICommand Detail { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }
    }
}
