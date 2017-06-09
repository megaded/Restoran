using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RestoranDesktop.ViewModel.Location
{
    public class LocationItemMenu
    {
        public string NameMenu { get; set; }
        public UserControl View { get; set; }
        public ICommand Open { get; set; }
    }
}
