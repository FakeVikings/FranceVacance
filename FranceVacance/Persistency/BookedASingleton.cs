using FranceVacance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Persistency
{
    class BookedASingleton
    {
        public static Accomodation Accomodation;
        private static BookedASingleton Instance { get; set; }

        private BookedASingleton()
        {
            DataCollectionClass.ReadFiles();
            Accomodation = new Accomodation();
        }
        public static BookedASingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BookedASingleton();
            }
            return Instance;
        }

        public void SetAccomodation(Accomodation accomodation)
        {
            Accomodation = accomodation;
        }


        public string GetCity()
        {
            return Accomodation.City;
        }
        public string GetCountry()
        {
            return Accomodation.Country;
        }
        public int GetPrice()
        {
            return Accomodation.Price;
        }
        public string GetImageUrl()
        {
            return Accomodation.ImageUrl;
        }
    }
    
}
