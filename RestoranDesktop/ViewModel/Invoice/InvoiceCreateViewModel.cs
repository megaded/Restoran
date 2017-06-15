using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranDesktop.Model;

namespace RestoranDesktop.ViewModel.Invoice
{
    public class InvoiceCreateViewModel : BaseViewModel
    {
        #region Private

        private string invoiceNumber;
        private int invoiceId;
        private string vATInvoice;
        private DateTime date;
        private int supplierId;

        #endregion

        #region Property
        public ObservableCollection<ProductInvoice> Products { get; set; }


        #endregion

        public InvoiceCreateViewModel()
        {
            
        }
    }
}
