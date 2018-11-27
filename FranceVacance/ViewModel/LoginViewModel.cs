using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;
using FranceVacance.Command;
using FranceVacance.View;
using FranceVacance.Persistency;
using System.Collections.ObjectModel;

namespace FranceVacance.ViewModel
{
    class LoginViewModel : NotifyViewModel
    {
        public RelayCommand GoCAVCommand { get; set; }
        public AccountCatalogSingleton Singleton;
        private ObservableCollection<Account> _accountsCollection;
        private AccountCatalogSingleton _accountCatalogSingleton;
        public RelayCommand LoginCommand{ get; set; }
        private string _email;
        private string _password;
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
        public ObservableCollection<Account> AccountsCollection
        {
            get { return _accountsCollection; }
            set
            {
                _accountsCollection = value;
                OnPropertyChanged("AccountsCollection");
            }
        }
        public LoginViewModel()
            {
            _accountCatalogSingleton = AccountCatalogSingleton.Instance;
            _accountsCollection = new ObservableCollection<Account>(_accountCatalogSingleton.AccountList);
            GoCAVCommand = new RelayCommand(GoCAV);
            Singleton = AccountCatalogSingleton.Instance;
            LoginCommand = new RelayCommand(Login);

            }
        public void GoCAV()
            {
            Type type = typeof(CreateAccountView);
            Navigate.ActivateFrameNavigation(type);

            }
        private void Login()
        {
            _accountCatalogSingleton.GainAccess(Email, Password);
        }
    }
}
