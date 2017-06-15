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
   public class UnitCreateViewModel:BaseViewModel
    {
        #region Private

        private string name { get; set; }
        private string symbol { get; set; }
        private  UnitAPI unitApi;       

        #endregion

        public string Name
        {
            get { return this.name; }
            set {
                if (this.name!=value)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                } }
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
        public ICommand Create { get; set; }

        public UnitCreateViewModel()
        {
            Create = new Command(CreateUnit);        
        }

        private void CreateUnit()
        {
            unitApi = new UnitAPI();
            var model = new UnitDTO()
            {
                Name =this.name,
                Symbol = this.symbol
            };
            var resultFlag = unitApi.Create(model);
            if (resultFlag)
            {
                MessageBox.Show("Успешно создано.");
            }
            if (!resultFlag)
            {
                MessageBox.Show("Ошибка при создании.");
            }
        }
    }
}
