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
        private Booking _selectedBooking;
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

        public Booking SelectedBooking
        {
            get => _selectedBooking;
            set
            {
                _selectedBooking = value;
                OnPropertyChanged("SelectedBooking");
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
            if (SelectedBooking.IsPaidFor)
            {
                MessageBox.Fail("You have already payed for this booking.");
            }
            else
            {
                SelectedBooking.IsPaidFor = true;
                MessageBox.Success("Your payment has been registered.");
            }
            
        }
    }
}
