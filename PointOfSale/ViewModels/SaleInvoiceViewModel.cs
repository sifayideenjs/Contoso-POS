using PointOfSale.Common;
using PointOfSale.Models;
using PointOfSale.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PointOfSale.ViewModels
{
    public class SaleInvoiceViewModel : ViewModelBase
    {
        private Invoice _invoice = null;
        private Customer _customer = null;
        private ObservableCollection<InvoiceSub> _invoiceSubList = new ObservableCollection<InvoiceSub>();
        private double _amountBeforeTax = 0.0;
        private double _taxApplicable = 4.0;
        private double _discounts = 0.0;
        private double _finalInvoiceAmount = 0.0;

        POSDBContext _context = new POSDBContext();
        InvoiceRepository _invoiceRepository = null;

        public SaleInvoiceViewModel(Invoice invoice)
        {
            if(invoice != null)
            {
                _invoiceRepository = new InvoiceRepository(_context);
                this.Invoice = invoice;
                this.Customer = invoice.Customer;
                var invoiceSubList = invoice.InvoiceSubs;
                this.InvoiceSubList = new ObservableCollection<InvoiceSub>(invoiceSubList);

                double[] totalAmountList = InvoiceSubList.Select(i => i.Amount).ToArray();
                this.AmountBeforeTax = totalAmountList.Sum();

                this.FinalInvoiceAmount = CalculateFinalInvoiceAmount();
            }

            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
            ExitCommand = new RelayCommand(OnExit);
        }
        public Invoice Invoice
        {
            get { return _invoice; }
            set
            {
                _invoice = value;
                OnPropertyChanged();
            }
        }

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<InvoiceSub> InvoiceSubList
        {
            get { return _invoiceSubList; }
            set
            {
                _invoiceSubList = value;
                OnPropertyChanged();
            }
        }

        public double AmountBeforeTax
        {
            get { return _amountBeforeTax; }
            set
            {
                _amountBeforeTax = value;
                OnPropertyChanged();
            }
        }

        public double TaxApplicable
        {
            get { return _taxApplicable; }
            set
            {
                _taxApplicable = value;
                OnPropertyChanged();
            }
        }

        public double Discounts
        {
            get { return _discounts; }
            set
            {
                _discounts = value;
                OnPropertyChanged();
            }
        }

        public double FinalInvoiceAmount
        {
            get { return _finalInvoiceAmount; }
            set
            {
                _finalInvoiceAmount = value;
                OnPropertyChanged();
            }
        }


        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private void OnSave(object arg)
        {
            this.FinalInvoiceAmount = CalculateFinalInvoiceAmount();
            //_invoiceRepository.Save();
        }

        private void OnCancel(object arg)
        {

        }

        private void OnExit(object arg)
        {
            Application.Current.MainWindow.Close();
        }

        private double CalculateFinalInvoiceAmount()
        {
            double taxableAmount = (_amountBeforeTax * (_taxApplicable / 100.0));
            double discountableAmount = (_amountBeforeTax * (_discounts / 100.0));
            return _amountBeforeTax + taxableAmount + discountableAmount;
        }
    }
}
