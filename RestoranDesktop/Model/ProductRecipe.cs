using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoranDesktop.Model
{
    public class ProductRecipe
    {
        public double Value { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
    }
}
