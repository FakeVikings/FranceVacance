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
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FranceVacance.ViewModel
{
    class MainPageViewModel : NotifyViewModel
    {

        public int SelectedIndex { get; } = 0; // 0 index
        public ObservableCollection<Accomodation> AccomodationList { get; set; }
        public RelayCommand AddAccomodationCommand { get; set; }
        public RelayCommand UpdateAccomodationCommand { get; set; }
        public RelayCommand DeleteAccomodationCommand { get; set; }
        public RelayCommand RefreshAccomodationCommand { get; set; }
        public RelayCommand GoApCommand { get; set; }

        // Add Accomodation
        public Accomodation AddAccomodation { get; set; }






        private AccountCatalogSingleton _accountCatalogSingleton;

        public string Country { get; set; }
        public string City { get; set; }
        public string Image { get; set; }


        
        // public readonly AccomodationCatalogSingleton AccomodationSingleton;
        private Accomodation _selectedItemAccomodation;
        public RelayCommand GoLoginViewCommand { get; set; }
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
       // public readonly Navigate FrameNavigate;

        private JsonFile _filePersistency;


        public MainPageViewModel()
        {
            // Data Persistency 
            _filePersistency = new JsonFile();
            AddAccomodationCommand = new RelayCommand(DoAddAccomodation);
            UpdateAccomodationCommand = new RelayCommand(DoUpdateAccomodation);
            DeleteAccomodationCommand = new RelayCommand(DoDeleteAccomodation);
            RefreshAccomodationCommand = new RelayCommand(DoRefreshAccomodation);
            AddAccomodation = new Accomodation();
            AccomodationList = new ObservableCollection<Accomodation>();
        }

        public async void DoAddAccomodation()
        {
            //string img = "../Assets/" + AddAccomodation.ImageUrl + ".jpg";
            //AddAccomodation.ImageUrl = img;
            AccomodationList.Add(AddAccomodation);
            await SaveAsyncMethod(AccomodationList);

        }

        public void DoUpdateAccomodation()
        {
        }

        public void DoDeleteAccomodation()
        {
        }

        public void DoRefreshAccomodation()
        {
        }


        public void GoLoginView()
        {
            Type type = typeof(LoginView);
            Navigate.ActivateFrameNavigation(typeof(LoginView));
        }
        
        public void GoAP()
        {
           // UserSingleton.SetAccomodation(SelectedItemAccomodation);

            Type type = typeof(AccomodationPage);
            Navigate.ActivateFrameNavigation(type);
        }

        public async void RunAsyncLoadData()
        {
            AccomodationList = await _filePersistency.LoadAsync();
        }
        // Load data from file
        public async Task<ObservableCollection<Accomodation>> LoadAsyncMethod()
        {
            return await _filePersistency.LoadAsync();
        }

        // Save data into file 
        public async Task SaveAsyncMethod(ObservableCollection<Accomodation> accomodations)
        {
            await _filePersistency.SaveAsync(accomodations);
        }
    }
}
