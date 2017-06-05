using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoranDesktop.Model
{
    public class ItemMenu
    {
        public string Name { get; set; }
        public ICommand Open { get; set; }


    }
}
