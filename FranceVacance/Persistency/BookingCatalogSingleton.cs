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
        //public List<Booking> BookingsList { get; set; }
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

        public void BookingVerification()
        {

        }

        private void AddBooking(Booking booking)
        {
            BookingsList.Add(booking);
        }

        public void BookAccommodation(Accommodation accommodation, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            Booking booking = new Booking(accommodation, startDate, endDate);
            AddBooking(booking);
            MessageBox.Success("Acc booked.");
        }


        




        /*
        public string GetCity()
        {
            return Booking.Country;
        }
        public string GetCountry()
        {
            return Accommodation.City;
        }
        public int GetPrice()
        {
            return Accommodation.PricePerNight;
        }
        public string GetImageUrl()
        {
            return Accommodation.ImageUrl;
        }
        */
    }
    
}
