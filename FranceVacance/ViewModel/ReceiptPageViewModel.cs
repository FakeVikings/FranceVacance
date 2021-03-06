﻿using System;
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
        public RelayCommand GoMainPageCommand { get; set; }
        public RelayCommand GoMyBookingPageCommand { get; set; }

        public ReceiptPageViewModel()
        {
            _bookingCatalogSingleton = BookingCatalogSingleton.Instance;
            _currentBooking = _bookingCatalogSingleton.CurrentBooking;
            GoMainPageCommand = new RelayCommand(GoMainPage);
            GoMyBookingPageCommand = new RelayCommand(GoMyBookingPage);
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
