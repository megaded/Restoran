using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoranDesktop.Model
{
  public  class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICommand Detail { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }
    }
}
