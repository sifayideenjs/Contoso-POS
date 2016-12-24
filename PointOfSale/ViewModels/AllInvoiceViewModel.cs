using PointOfSale.Common;
using PointOfSale.Models;
using PointOfSale.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PointOfSale.ViewModels
{
    public class AllInvoiceViewModel : ViewModelBase
    {
        private ObservableCollection<Invoice> _invoiceList = new ObservableCollection<Invoice>();
        private Invoice _selectedInvoice = null;
        private double _overAllSale = 0.0;
        private double _overAllProfit = 0.0;

        public AllInvoiceViewModel()
        {
            POSDBContext context = new POSDBContext();
            InvoiceRepository repository = new InvoiceRepository(context);
            var invoiceList = repository.Get();
            var todaysInvoices = invoiceList.Where(i => i.DateTime.Date == DateTime.Now.Date).ToList();
            InvoiceList = new ObservableCollection<Invoice>(todaysInvoices);

            double[] totalAmountList = todaysInvoices.Select(i => i.FinalAmount).ToArray();
            OverAllSale = totalAmountList.Sum();

            double[] totalProfitList = todaysInvoices.Select(i => i.Profit).ToArray();
            OverAllProfit = totalProfitList.Sum();
        }

        public ObservableCollection<Invoice> InvoiceList
        {
            get { return _invoiceList; }
            set
            {
                _invoiceList = value;
                OnPropertyChanged();
            }
        }

        public Invoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set
            {
                _selectedInvoice = value;
                OnPropertyChanged();
            }
        }

        public double OverAllSale
        {
            get { return _overAllSale; }
            set
            {
                _overAllSale = value;
                OnPropertyChanged();
            }
        }

        public double OverAllProfit
        {
            get { return _overAllProfit; }
            set
            {
                _overAllProfit = value;
                OnPropertyChanged();
            }
        }
    }
}
