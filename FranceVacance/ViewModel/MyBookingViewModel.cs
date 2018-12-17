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
            _bookingsObservableCollection = new ObservableCollection<Booking>(_bookingCatalogSingleton.BookingsList.FindAll(x => x.User == Session.LoggedInUser));
            GoMainPageCommand = new RelayCommand(GoMainPage);
            GoLoginViewCommand = new RelayCommand(GoLoginView);
            PayCommand = new RelayCommand(Pay);
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
