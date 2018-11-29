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
        public ObservableCollection<Accomodation> AccomodationList { get; set; }
        public AccountCatalogSingleton Singleton { get; }

        private AccountCatalogSingleton _accountCatalogSingleton;

        public string Country { get; set; }
        public string City { get; set; }

        public string Image { get; set; }

        public readonly AccomodationCatalogSingleton UserSingleton;
        private Accomodation _selectedItemAccomodation;
        public Accomodation AddAccomodation { get; set; }
        public RelayCommand GoLoginViewCommand { get; set; }
        public RelayCommand GoCAVCommand { get; set; }
        public RelayCommand AddAccomodationCommand { get; set; }
        public RelayCommand UpdateAccomodationCommand { get; set; }
        public RelayCommand DeleteAccomodationCommand { get; set; }
        public RelayCommand RefreshAccomodationCommand { get; set; }
        public RelayCommand GoAPCommand { get; set; }

        public Accomodation SelectedItemAccomodation
        {
            get => _selectedItemAccomodation;
            set
            {
                _selectedItemAccomodation = value;
                OnPropertyChanged(nameof(SelectedItemAccomodation));
            }
        }
        public readonly Navigate FrameNavigate;
        public MainPageViewModel()
        {
            UserSingleton = AccomodationCatalogSingleton.GetInstance();
            SelectedItemAccomodation = new Accomodation();
            AddAccomodation = new Accomodation();

            // Relay Command 
            AddAccomodationCommand = new RelayCommand(DoAddAccomodation);
            UpdateAccomodationCommand = new RelayCommand(DoUpdateAccomodation);
            DeleteAccomodationCommand = new RelayCommand(DoDeleteAccomodation);
            RefreshAccomodationCommand = new RelayCommand(DoRefreshAccomodation);
            GoAPCommand = new RelayCommand(GoAP);
            AccomodationList = new ObservableCollection<Accomodation>() { new Accomodation(country: "France", city: "Marseille", imageUrl: "Cottage.jpg"),
                new Accomodation(country: "France", city: "Paris", imageUrl: "Cottage.jpg"),
                new Accomodation(country: "France", city: "Paris", imageUrl: "Cottage.jpg"), };
            GoCAVCommand = new RelayCommand(GoCAV);
            Singleton = AccountCatalogSingleton.Instance;
            GoLoginViewCommand = new RelayCommand(GoLoginView);
            _accountCatalogSingleton = AccountCatalogSingleton.Instance;
            _accountsCollection = new ObservableCollection<Account>(_accountCatalogSingleton.AccountList);
            Country = Accomodation.GetCountry();
            City = Accomodation.GetCity();
            Image = Accomodation.GetImageUrl();
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
        public void DoAddAccomodation()
        {
            // add the name of image in URL path
            string img = "../Assets/" + AddAccomodation.ImageUrl + ".jpg";
            AddAccomodation.ImageUrl = img;
            AccomodationList.Add(AddAccomodation);
        }
        public void DoUpdateAccomodation()
        {
            AccomodationList = new ObservableCollection<Accomodation>()
            {
                new Accomodation(SelectedItemAccomodation.Country, SelectedItemAccomodation.City,SelectedItemAccomodation.ImageUrl)
            };
        }
        public void DoDeleteAccomodation()
        {
            AccomodationList.Remove(SelectedItemAccomodation);
        }
        public void DoRefreshAccomodation()
        {
            AccomodationList = new ObservableCollection<Accomodation>() { new Accomodation(country: "France", city: "Marseille", imageUrl: "Cottage.jpg"),
                new Accomodation(country: "France", city: "Paris", imageUrl: "Cottage.jpg"),
                new Accomodation(country: "France", city: "Paris", imageUrl: "Cottage.jpg"), };
            OnPropertyChanged(nameof(AccomodationList));
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
        public void GoAP()
        {
            UserSingleton.SetAccomodation(SelectedItemAccomodation);

            Type type = typeof(AccomodationPage);
            Navigate.ActivateFrameNavigation(type);
        }
    }
}
