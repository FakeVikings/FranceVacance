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
        public DateTime _startDate;
        public DateTime _endDate;
        public string City { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        private string _imageUrl {get; set;}

        
   
      

        public RelayCommand GoMainPageCommand { get; set; }

        public RelayCommand GoBookingPageCommand { get; set; }

        private BookingCatalogSingleton _bookingCatalogSingleton;

        private ObservableCollection<Booking> _bookingsList;

        public Booking AddBooking { get; set; }


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

            Singleton = AccommodationCatalogSingleton.GetInstance();
            GoMainPageCommand = new RelayCommand(GoMainPage);
            GoBookingPageCommand = new RelayCommand(BookAccommodation);
            //bookingsCollection = new ObservableCollection<Booking>(BookingCatalogSingleton.BookingsList);

            Country = Singleton.GetCountry();
            City = Singleton.GetCity();
            ImageUrl = Singleton.GetImageUrl();
            Price = Singleton.GetPrice();

            AddBooking = new Booking(32, new DateTime(2013, 1, 14), new DateTime(2013, 1, 18));

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

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public void BookAccommodation()
        {
            if (StartDate !=null && EndDate !=null)
            {
                BookingsList.Add(AddBooking);
                MessageBox.Success("You have booked accomodation");
                Type type = typeof(MyBooking);
                Navigate.ActivateFrameNavigation(typeof(MyBooking));
            }

        }



        public void GoMainPage()
        {
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
