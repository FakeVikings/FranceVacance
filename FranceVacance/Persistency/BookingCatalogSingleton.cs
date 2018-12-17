using FranceVacance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.ViewModel;

namespace FranceVacance.Persistency
{
    class BookingCatalogSingleton
    {
        public Booking CurrentBooking { get; set; }
        public List<Booking> BookingsList;
        private static BookingCatalogSingleton _instance;

        private BookingCatalogSingleton()
        {
            DataCollection.ReadFiles();
            //Booking = new Booking(32, new DateTime(2019, 1, 20), new DateTime(2019, 1, 28));
            BookingsList = new List<Booking>();

        }

        public static BookingCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookingCatalogSingleton();
                }

                return _instance;
            }
        }

        private void AddBooking(Booking booking)
        {
            BookingsList.Add(booking);
            MessageBox.Success("Accommodation has been booked.");
        }

        public void BookAccommodation(Accommodation accommodation, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            if (VerifyBooking.VerifyNewBooking(accommodation, startDate, endDate))
            {
                Booking booking = new Booking(accommodation, startDate, endDate);
                AddBooking(booking);
            }
            
        }
    }
}
