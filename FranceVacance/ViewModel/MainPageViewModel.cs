using FranceVacance.Command;
using FranceVacance.Model;
using FranceVacance.Persistency;
using FranceVacance.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.DataTransfer;
using Windows.Graphics.Printing3D;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FranceVacance.ViewModel
{
    class MainPageViewModel : NotifyViewModel
    {

        private string _country;
        private string _city;
        private int _price;
        private string _imageUrl;
        private bool _admin;
        private Visibility _adminStackVisibility;




        public int SelectedIndex { get; } = 0; // 0 index
        private ObservableCollection<Accommodation> _accomodationsList;


        public ObservableCollection<Accommodation> AccomodationList
        {
            get { return _accomodationsList; }
            set
            {
                _accomodationsList = value;
                OnPropertyChanged(nameof(AccomodationList));
            }
        }

        public RelayCommand AddAccomodationCommand { get; set; }
        public RelayCommand UpdateAccomodationCommand { get; set; }
        public RelayCommand DeleteAccomodationCommand { get; set; }
        public RelayCommand RefreshAccomodationCommand { get; set; }
        public RelayCommand GoAccomodationViewCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        

        // Add Accommodation
        public Accommodation AddAccommodation { get; set; }


        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged("ImageUrl");
            }
        }

        public bool Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
                OnPropertyChanged("Admin");
            }
        }


        public readonly AccommodationCatalogSingleton AccommodationCatalogSingleton;
        private Accommodation _selectedItemAccommodation;
        public RelayCommand GoLoginViewCommand { get; set; }
        public RelayCommand GoAPCommand { get; set; }

        public RelayCommand GoMyBookingsCommand { get; set; }

        public Accommodation SelectedItemAccommodation
        {
            get => _selectedItemAccommodation;
            set
            {
                _selectedItemAccommodation = value;
                OnPropertyChanged(nameof(SelectedItemAccommodation));
            }
        }
        // public readonly Navigate FrameNavigate;

        private JsonFile<Accommodation> _filePersistency;



        

        public MainPageViewModel()
        {
            // Data Persistency 
            AccomodationList = DataCollection.AccomodationListM();

            RunAsyncLoadData();


            _filePersistency = new JsonFile<Accommodation>();

            AddAccomodationCommand = new RelayCommand(DoAddAccomodation);
            UpdateAccomodationCommand = new RelayCommand(DoUpdateAccomodation);
            DeleteAccomodationCommand = new RelayCommand(DoDeleteAccomodation);
            RefreshAccomodationCommand = new RelayCommand(DoRefreshAccomodation);

            GoAccomodationViewCommand = new RelayCommand(GoAccomodationView);
            GoMyBookingsCommand = new RelayCommand(GoMyBookings);
            GoLoginViewCommand = new RelayCommand(GoLoginView);

            SearchCommand = new RelayCommandArg(SearchData);
            AddAccommodation = new Accommodation();

            AccommodationCatalogSingleton = AccommodationCatalogSingleton.GetInstance();
            AdminCheck();
            

        }

        public async void DoAddAccomodation()
        {
          
                string img = "../Assets/" + AddAccommodation.ImageUrl + ".jpg";
                AddAccommodation.ImageUrl = img;
                AccomodationList.Add(AddAccommodation);
                await SaveAsyncMethod(AccomodationList);
            
           

        }

        public void DoUpdateAccomodation()
        {
            foreach (var lis in AccomodationList)
            {
                    lis.City = SelectedItemAccommodation.City;
                    lis.Country = SelectedItemAccommodation.Country;
                    lis.PricePerNight = SelectedItemAccommodation.PricePerNight;
                    lis.ImageUrl = SelectedItemAccommodation.ImageUrl;
            }

        }

        public void DoDeleteAccomodation()
        {
            AccomodationList.Remove(SelectedItemAccommodation);
        }

        public void DoRefreshAccomodation()
        {
            AccomodationList = DataCollection.AccomodationListM();
        }


        public void GoLoginView()
        {
            Type type = typeof(LoginView);
            Navigate.ActivateFrameNavigation(typeof(LoginView));
        }
        public void GoMyBookings()
        {
            Type type = typeof(MyBooking);
            Navigate.ActivateFrameNavigation(typeof(MyBooking));
        }

        public void GoAccomodationView()
        {
            AccommodationCatalogSingleton.SetAccomodation(SelectedItemAccommodation);

            Type type = typeof(AccomodationPage);
            Navigate.ActivateFrameNavigation(typeof(AccomodationPage));
        }

        public async void RunAsyncLoadData()
        {
            // AccomodationList = await _filePersistency.LoadAsync();
        }
        //Load data from file
        public async Task<ObservableCollection<Accommodation>> LoadAsyncMethod()
        {
            return await _filePersistency.LoadAsync();
        }

        // Save data into file 
        public async Task SaveAsyncMethod(ObservableCollection<Accommodation> accomodations)
        {
            await _filePersistency.SaveAsync(accomodations);
        }

        // Handling problems

        private ObservableCollection<Accommodation> _searchAccomodationList;
        // search system 
        public void SearchData(object city)
        {
            var searchCity = city as string;
            foreach (var se in AccomodationList)
            {
                if (se.City == searchCity)
                {
                    _searchAccomodationList = new ObservableCollection<Accommodation>()
                    {
                        new Accommodation(se.Country , se.City,se.PricePerNight,se.ImageUrl)
                    };
                }
            }

            AccomodationList = _searchAccomodationList;
            OnPropertyChanged(nameof(AccomodationList));
        }


      

        public Visibility AdminStackVisibility
        {
         
            get => _adminStackVisibility;
            set
            {
                OnPropertyChanged(nameof(AdminStackVisibility));
                _adminStackVisibility = value;
            }
        }


        public void AdminCheck()
        {
            if (Session.LogedInUser.Admin == true)
            {
                AdminStackVisibility = Visibility.Visible;
            }
            else
            {
                AdminStackVisibility = Visibility.Collapsed;
            }
        }

    }
}
