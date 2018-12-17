using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.Storage;
using Windows.UI.Composition;
using Windows.UI.Popups;
using FranceVacance.Model;
using FranceVacance.ViewModel;
using FranceVacance.View;
using Newtonsoft.Json;

namespace FranceVacance.Persistency
{
    public class AccommodationCatalogSingleton
    {
     
        public Accommodation Accommodation { get; set; }

        // step 1 : declare the object instance of class Singleton 
        private static AccommodationCatalogSingleton Instance { get; set; }

        private AccommodationCatalogSingleton()
        {
            DataCollection.ReadFiles();
            // create an object instance of your business class
            Accommodation = new Accommodation();
        }

        // step 2:  this instance property check first if instance is not null ,
        // if its null then create an object instance otherwise return current instance 

        public static AccommodationCatalogSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AccommodationCatalogSingleton();
            }
            return Instance;
        }
        // Create method based upon your business logic 

        public void SetAccomodation(Accommodation accommodation)
        {
            Accommodation = accommodation;
        }

      
        public string GetCity()
        {
            return Accommodation.City;
        }
        public string GetCountry()
        {
            return Accommodation.Country;
        }
        public int GetPrice()
        {
            return Accommodation.PricePerNight;
        }
        public string GetImageUrl()
        {
            return Accommodation.ImageUrl;
        }

    }
}

