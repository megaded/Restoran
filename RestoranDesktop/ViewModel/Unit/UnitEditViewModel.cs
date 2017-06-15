using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestoranDesktop.Model;
using RestoranSDK;
using RestoranSDK.DTO;

namespace RestoranDesktop.ViewModel.Unit
{
    public class UnitEditViewModel : BaseViewModel
    {
        #region Private

        private int id { get; set; }
        private string name { get; set; }
        private string symbol { get; set; }
        private UnitAPI unitApi;


        #endregion

        #region Property
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

        public string Symbol
        {
            get { return this.symbol; }
            set
            {
                if (this.symbol != value)
                {
                    this.symbol = value;
                    NotifyPropertyChanged("Symbol");
                }
            }
        }

        public ICommand Edit { get; set; }


        #endregion

        public UnitEditViewModel(Model.Unit unit)
        {
            this.id = unit.UnitId;
            this.name = unit.Name;
            this.symbol = unit.Symbol;
            Edit = new Command(EditUnit);
        }

        private void EditUnit()
        {
            unitApi = new UnitAPI();
            var model = new UnitDTO()
            {
                Id = this.id,
                Name = this.name,
                Symbol = this.symbol
            };
            var resultFlag = unitApi.Update(model);
            if (resultFlag)
            {
                MessageBox.Show("Успешно сохранено.");
            }
            if (!resultFlag)
            {
                MessageBox.Show("Не удачно.");
            }
        }
    }
}
