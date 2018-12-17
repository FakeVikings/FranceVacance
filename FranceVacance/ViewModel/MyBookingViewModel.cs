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
    class MyBookingViewModel : NotifyViewModel
    {
        private BookingCatalogSingleton _bookingCatalogSingleton;
        private ObservableCollection<Booking> _bookingsObservableCollection;
        private string _country;
        private string _city;
        private int _pricePerNight;
        private DateTimeOffset _startDate;
        private DateTimeOffset _endDate;
        private int _price;
        public RelayCommand GoMainPageCommand { get; set; }
        public RelayCommand PayCommand { get; set; }
        public RelayCommand GoLoginViewCommand { get; set; }

    public MyBookingViewModel()
        {
            _bookingCatalogSingleton = BookingCatalogSingleton.Instance;
            _bookingsObservableCollection = new ObservableCollection<Booking>(_bookingCatalogSingleton.BookingsList);
            GoMainPageCommand = new RelayCommand(GoMainPage);
            PayCommand = new RelayCommand(Pay);
            GoLoginViewCommand = new RelayCommand(GoLoginView);
        }

        public ObservableCollection<Booking> BookingsObservableCollection
        {
            get => _bookingsObservableCollection;
            set
            {
                _bookingsObservableCollection = value;
                OnPropertyChanged("BookingsObservableCollection");
            }
        }
        /*
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public int PricePerNight
        {
            get => _pricePerNight;
            set
            {
                _pricePerNight = value;
                OnPropertyChanged("PricePerNight");
            }
        }

        public DateTimeOffset StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public DateTimeOffset EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        */
        public void GoMainPage()
        {
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }

        public void GoLoginView()
        {
            Navigate.ActivateFrameNavigation(typeof(LoginView));
        }

        public void Pay()
        {
            
        }
    }
}
