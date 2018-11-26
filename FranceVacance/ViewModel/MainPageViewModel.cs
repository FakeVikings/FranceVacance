using FranceVacance.Command;
using FranceVacance.Model;
using FranceVacance.Persistency;
using FranceVacance.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.ViewModel
{
    class MainPageViewModel : NotifyViewModel
    {
        private ObservableCollection<Account> _accountsCollection;
        public RelayCommand GoLoginViewCommand { get; set; }
        public RelayCommand GoCAVCommand { get; set; }
        public AccountCatalogSingleton Singleton { get; }

        private AccountCatalogSingleton _accountCatalogSingleton;

        public MainPageViewModel()
        {
            GoCAVCommand = new RelayCommand(GoCAV);
            Singleton = AccountCatalogSingleton.Instance;
            GoLoginViewCommand = new RelayCommand(GoLoginView);
            _accountCatalogSingleton = AccountCatalogSingleton.Instance;
            _accountsCollection = new ObservableCollection<Account>(_accountCatalogSingleton.AccountList);
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

        public void GoLoginView()
        {
            Type type = typeof(LoginView);
            Navigate.ActivateFrameNavigation(typeof(LoginView));
        }
        public void GoCAV()
        {
            Type type = typeof(CreateAccountView);
            Navigate.ActivateFrameNavigation(typeof(CreateAccountView));
        }
    }
}
