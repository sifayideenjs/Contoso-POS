using PointOfSale.Common;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PointOfSale.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private string _domain = string.Empty;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(OnLogin);
            CancelCommand = new RelayCommand(OnCancel);
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Domain
        {
            get { return _domain; }
            set
            {
                _domain = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private void OnLogin(object arg)
        {
            if (AuthenticateUser(_domain, _userName, _password))
            {
            }
            else MessageBox.Show("Unable to Authenticate Using the Supplied Credentials");
        }

        private void OnCancel(object arg)
        {

        }

        private bool AuthenticateUser(string domainName, string userName, string password)
        {
            bool result = false;

            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + _domain, _userName, _password);
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
                SearchResult results = null;
                results = directorySearcher.FindOne();
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
