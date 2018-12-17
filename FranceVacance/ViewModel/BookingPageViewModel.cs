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
    class BookingPageViewModel : NotifyViewModel
    {
        private DateTimeOffset _startDate;
        private DateTimeOffset _endDate;
        public string City { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        private string _imageUrl {get; set;}
        public RelayCommand GoMainPageCommand { get; set; }
        public RelayCommand BookAccommodationCommand { get; set; }
        private BookingCatalogSingleton _bookingCatalogSingleton;
        private ObservableCollection<Booking> _bookingsList;

        //       public Booking AddBooking { get; set; }


        public ObservableCollection<Booking> BookingsList
        {
            get { return _bookingsList; }
            set
            {
                _bookingsList = value;
                OnPropertyChanged(nameof(BookingsList));
            }
        }


        public AccommodationCatalogSingleton Singleton;

        public BookingPageViewModel()
        {
            BookingsList = DataCollection.BookingsCollection();
            _bookingCatalogSingleton = BookingCatalogSingleton.Instance;
            Singleton = AccommodationCatalogSingleton.GetInstance();
            GoMainPageCommand = new RelayCommand(GoMainPage);
            BookAccommodationCommand = new RelayCommand(Book);
            //bookingsCollection = new ObservableCollection<Booking>(BookingCatalogSingleton.BookingsList);

            Country = Singleton.GetCountry();
            City = Singleton.GetCity();
            ImageUrl = Singleton.GetImageUrl();
            Price = Singleton.GetPrice();
            //AddBooking = new Booking(32, new DateTime(2013, 1, 14), new DateTime(2013, 1, 18));
            _startDate = new DateTimeOffset(DateTime.Today);
            _endDate = new DateTimeOffset(DateTime.Today);

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

        public DateTimeOffset StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public DateTimeOffset EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public void Book()
        {
            _bookingCatalogSingleton.BookAccommodation(Singleton.Accommodation, StartDate, EndDate);
            _bookingCatalogSingleton.CurrentBooking = _bookingCatalogSingleton.BookingsList.Find(x => x.Accommodation == Singleton.Accommodation);
            GoReceiptPage();
        }

        public void GoReceiptPage()
        {
            Navigate.ActivateFrameNavigation(typeof(ReceiptPage));
        }

        public void GoMainPage()
        {
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
