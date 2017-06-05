using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoranDesktop.Model
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public  Action Action { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action();

        }

        public Command()
        {
            
        }
        public Command(Action action)
        {
            this.Action = action;
        }
    }
}
