using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Command;
using FranceVacance.Model;
using FranceVacance.Persistency;
using FranceVacance.View;

namespace FranceVacance.ViewModel
{
    public class ReceiptPageViewModel : NotifyViewModel
    {
        private BookingCatalogSingleton _bookingCatalogSingleton;
        private Booking _currentBooking;
        /*private string _fullname;
        private string _email;
        private string _country;
        private string _city;
        private int _pricePerNight;
        private DateTimeOffset _startDate;
        private DateTimeOffset _endDate;
        private int _price;*/
        public RelayCommand GoMainPageCommand { get; set; }
        public RelayCommand GoMyBookingPageCommand { get; set; }

        public ReceiptPageViewModel()
        {
            _bookingCatalogSingleton = BookingCatalogSingleton.Instance;
            _currentBooking = _bookingCatalogSingleton.CurrentBooking;
            GoMainPageCommand = new RelayCommand(GoMainPage);
            GoMyBookingPageCommand = new RelayCommand(GoMyBookingPage);
            /*
            Fullname = _bookingCatalogSingleton.CurrentBooking.User.Fullname;
            Email = _bookingCatalogSingleton.CurrentBooking.User.Email;
            Country = _bookingCatalogSingleton.CurrentBooking.Accommodation.Country;
            City = _bookingCatalogSingleton.CurrentBooking.Accommodation.City;
            PricePerNight = _bookingCatalogSingleton.CurrentBooking.Accommodation.PricePerNight;
            StartDate = _bookingCatalogSingleton.CurrentBooking.StartDate;
            EndDate = _bookingCatalogSingleton.CurrentBooking.EndDate;
            Price = _bookingCatalogSingleton.CurrentBooking.Price;
            */
        }

        public Booking CurrentBooking
        {
            get { return _currentBooking; }
            set
            {
                _currentBooking = value;
                OnPropertyChanged("CurrentBooking");
            }
        }

        /*
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
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

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

        public void GoMyBookingPage()
        {
            Navigate.ActivateFrameNavigation(typeof(MyBooking));
        }
    }
}
