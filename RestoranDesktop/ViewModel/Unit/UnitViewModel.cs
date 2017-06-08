using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestoranDesktop.Model;
using RestoranDesktop.View.Unit;
using RestoranDesktop.ViewModel.Unit;
using RestoranSDK;

namespace RestoranDesktop.ViewModel
{
    public class UnitViewModel
    {
        private UnitAPI unitApi;
        public ObservableCollection<Model.Unit> Units { get; set; }
        public ICommand Create { get; set; }
        public UnitViewModel()
        {
            unitApi = new UnitAPI();
            var units = unitApi.GetAll().Select(x => new Model.Unit()
            {
                Name = x.Name,
                Symbol = x.Symbol,
                UnitId = x.Id,
                Delete = new Command(() =>
                {
                    Delete(x.Id);
                }),
                Edit = new Command(() =>
                {
                    Edit(x.Id);
                })

            });
            Units = new ObservableCollection<Model.Unit>(units);
            Create = new Command((() =>
              {
                  var view = new UnitCreateView();
                  view.Show();
              }));
        }

        #region Private Method

        private void Delete(int unitId)
        {

            var result = MessageBox.Show("Вы уверены", "Подтвердите удаление", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                var resultFlag = unitApi.Delete(unitId);
                if (resultFlag)
                {
                    MessageBox.Show("Успешно удалено.");
                    Units.Remove(Units.Single(y => y.UnitId == unitId));
                }
                if (!resultFlag)
                {
                    MessageBox.Show("Ошибка.");
                }
            }
        }

        private void Edit(int unitId)
        {
            var model = Units.Single(x => x.UnitId == unitId);
            var view = new UnitEditView();
            var viewmodel = new UnitEditViewModel(model);
            view.DataContext = viewmodel;
            view.Show();
        }

        private void Detail(int unitId)
        {

        }
        #endregion

    }
}
