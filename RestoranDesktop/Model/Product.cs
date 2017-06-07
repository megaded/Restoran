using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoranDesktop.Model
{
    public class Product:INotifyPropertyChanged
    {

        #region Private

        private int productID { get; set; }
        private string name { get; set; }

        private string description { get; set; }

        private  string unit { get; set; }
        private int unitID { get; set; }
        #endregion

        #region Property
        public int ProductId { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string Description { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public ICommand Detail { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }


        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
