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
        private ObservableCollection<Accomodation> _accomodationsList;


        public ObservableCollection<Accomodation> AccomodationList
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
        

        // Add Accomodation
        public Accomodation AddAccomodation { get; set; }


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

        private JsonFile<Accomodation> _filePersistency;



        

        public MainPageViewModel()
        {
            // Data Persistency 
            AccomodationList = DataCollectionClass.AccomodationList();

            RunAsyncLoadData();


            _filePersistency = new JsonFile<Accomodation>();
            AddAccomodationCommand = new RelayCommand(DoAddAccomodation);
            UpdateAccomodationCommand = new RelayCommand(DoUpdateAccomodation);
            DeleteAccomodationCommand = new RelayCommand(DoDeleteAccomodation);
            RefreshAccomodationCommand = new RelayCommand(DoRefreshAccomodation);
            GoAccomodationViewCommand = new RelayCommand(GoAccomodationView);
            SearchCommand = new RelayCommandArg(SearchData);

            AddAccomodation = new Accomodation();
            GoLoginViewCommand = new RelayCommand(GoLoginView);

            AccommodationCatalogSingleton = AccommodationCatalogSingleton.GetInstance();

            AdminStackVisibility = Visibility.Visible;
            

        }

        public async void DoAddAccomodation()
        {
          
                string img = "../Assets/" + AddAccomodation.ImageUrl + ".jpg";
                AddAccomodation.ImageUrl = img;
                AccomodationList.Add(AddAccomodation);
                await SaveAsyncMethod(AccomodationList);
            
           

        }

        public void DoUpdateAccomodation()
        {
        }

        public void DoDeleteAccomodation()
        {
            AccomodationList.Remove(SelectedItemAccomodation);
        }

        public void DoRefreshAccomodation()
        {
            AccomodationList = DataCollectionClass.AccomodationList();
        }


        public void GoLoginView()
        {
            Type type = typeof(LoginView);
            Navigate.ActivateFrameNavigation(typeof(LoginView));
        }
        
        public void GoAccomodationView()
        {
            AccommodationCatalogSingleton.SetAccomodation(SelectedItemAccomodation);

            Type type = typeof(AccomodationPage);
            Navigate.ActivateFrameNavigation(typeof(AccomodationPage));
        }

        public async void RunAsyncLoadData()
        {
            // AccomodationList = await _filePersistency.LoadAsync();
        }
        //Load data from file
        public async Task<ObservableCollection<Accomodation>> LoadAsyncMethod()
        {
            return await _filePersistency.LoadAsync();
        }

        // Save data into file 
        public async Task SaveAsyncMethod(ObservableCollection<Accomodation> accomodations)
        {
            await _filePersistency.SaveAsync(accomodations);
        }

        // Handling problems

        private ObservableCollection<Accomodation> _searchAccomodationList;
        // search system 
        public void SearchData(object city)
        {
            var searchCity = city as string;
            foreach (var se in AccomodationList)
            {
                if (se.City == searchCity)
                {
                    _searchAccomodationList = new ObservableCollection<Accomodation>()
                    {
                        new Accomodation(se.Country , se.City,se.Price,se.ImageUrl)
                    };
                }
            }

            AccomodationList = _searchAccomodationList;
            OnPropertyChanged(nameof(AccomodationList));
        }


        // Visibility 


        public Visibility AdminStackVisibility
        {
         
            get => _adminStackVisibility;
            set
            {
                OnPropertyChanged(nameof(AdminStackVisibility));
                _adminStackVisibility = value;
            }
        }


    }
    }
