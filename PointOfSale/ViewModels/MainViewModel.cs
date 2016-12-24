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
    public class MainViewModel : ViewModelBase
    {
        private AllInvoiceViewModel _allInvoiceViewModel = null;
        private ViewModelBase _selectedMenu = null;

        public MainViewModel()
        {
            _allInvoiceViewModel = new AllInvoiceViewModel();
            this.SelectedMenu = _allInvoiceViewModel;

            InvoiceCommand = new RelayCommand(OnInvoice);
            ViewSaleCommand = new RelayCommand(OnViewSale);
        }

        public ViewModelBase SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
                OnPropertyChanged();
            }
        }

        public ICommand InvoiceCommand { get; set; }
        public ICommand ViewSaleCommand { get; set; }

        private void OnInvoice(object arg)
        {
            if (_allInvoiceViewModel == null) _allInvoiceViewModel = new AllInvoiceViewModel();
            this.SelectedMenu = _allInvoiceViewModel;
        }

        private void OnViewSale(object arg)
        {
            if (_allInvoiceViewModel != null)
            {
                this.SelectedMenu = new SaleInvoiceViewModel(_allInvoiceViewModel.SelectedInvoice);
            }
        }
    }
}
