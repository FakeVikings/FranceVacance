using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using FranceVacance.Command;
using FranceVacance.Model;
using FranceVacance.View;
using FranceVacance.Persistency;

namespace FranceVacance.ViewModel
{
    class CreateAccountViewModel : NotifyViewModel
    {
        private string _fullname;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private ObservableCollection<Account> _accountsCollection;
        private AccountCatalogSingleton _accountCatalogSingleton;
        public RelayCommand CreateAccountCommand { get; set; }
        public RelayCommand GoLoginViewCommand { get; set; }

        public CreateAccountViewModel()
        {
            GoLoginViewCommand = new RelayCommand(GoLoginView);
            _accountCatalogSingleton = AccountCatalogSingleton.Instance;
            CreateAccountCommand = new RelayCommand(NewAccount);
            _accountsCollection = new ObservableCollection<Account>(_accountCatalogSingleton.AccountsList);
        }
        
        public string Fullname
        {
            get { return _fullname; }
            set
            {
                _fullname = value;
                OnPropertyChanged("Fullname");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public ObservableCollection<Account> AccountsCollection
        {
            get { return _accountsCollection; }
            set
            {
                _accountsCollection = value;
                OnPropertyChanged("AccountsCollection");
            }
        }

        private void NewAccount()
        {
            if (Password == ConfirmPassword)
            {
                _accountCatalogSingleton.CreateAccount(Fullname, Email, Password);
            }
            else
            {
                MessageBox.Fail("Passwords do not match.");
            }
        }

        public void GoLoginView()
        {
            Type type = typeof(LoginView);
            Navigate.ActivateFrameNavigation(typeof(LoginView));
        }
    }
}

