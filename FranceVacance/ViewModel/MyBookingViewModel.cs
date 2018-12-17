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
        private string _country;
        private string _city;
        private int _price;
        private string _imageUrl;
        private ObservableCollection<Accommodation> _myBookedAList;
        public int SelectedIndex { get; } = 0;
        public RelayCommand GoMainPageCommand { get; set; }
        public BookingCatalogSingleton _bookingCatalogSingleton;
        private Accommodation _MyAccommodation;

        public Accommodation MyAccommodation
        {
            get { return _MyAccommodation; }
            set
            {
                _MyAccommodation = value;
                OnPropertyChanged("MyAccommodation");
            }
        }

        public MyBookingViewModel()
        {
            GoMainPageCommand = new RelayCommand(GoMainPage);
            _bookingCatalogSingleton = BookingCatalogSingleton.Instance;
            MyAccommodation = _bookingCatalogSingleton.CurrentBooking.Accommodation;


            //  City = Singleton.GetCity();
            // ImageUrl = Singleton.GetImageUrl();
            // Price = Singleton.GetPrice();
        }

        public void GoMainPage()
        {
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
        public ObservableCollection<Accommodation> MyBookedAList
        {
            get { return _myBookedAList; }
            set
            {
                _myBookedAList = value;
                OnPropertyChanged(nameof(MyBookedAList));
            }
        }
    }
}
