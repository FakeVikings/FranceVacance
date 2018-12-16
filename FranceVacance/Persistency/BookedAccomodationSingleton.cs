using FranceVacance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Persistency
{
    class BookedAccomodationSingleton
    {
        //public List<Booking> BookingsList { get; set; }
        public static Booking Booking;

        private static BookedAccomodationSingleton Instance { get; set; }
        DateTime starTime = new DateTime(2008, 3, 9, 16, 5, 7, 123);
        DateTime enTime = new DateTime(2008, 3, 9, 16, 5, 7, 123);

        private BookedAccomodationSingleton()
        {
            DataCollectionClass.ReadFiles();
            Booking = new Booking(32, new DateTime(2019, 1, 20), new DateTime(2019, 1, 28));


        }
        public static BookedAccomodationSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BookedAccomodationSingleton();
            }
            return Instance;
        }

        public void BookingVerification()
        {

        }
        public void SetAccomodation(Booking booking)
        {
            Booking = booking;
        }




        /*
        public string GetCity()
        {
            return Booking.Country;
        }
        public string GetCountry()
        {
            return Accomodation.City;
        }
        public int GetPrice()
        {
            return Accomodation.PricePerNight;
        }
        public string GetImageUrl()
        {
            return Accomodation.ImageUrl;
        }
        */
    }
    
}
