using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.UI.Composition;
using FranceVacance.Model;
using FranceVacance.ViewModel;
using FranceVacance.View;

namespace FranceVacance.Persistency
{
    public class AccomodationCatalogSingleton
    {
        // step 1 : declare the object instance of class Singleton 
        private static AccomodationCatalogSingleton Instance { get; set; }
        internal List<Accomodation> AccomodationList { get; private set; }
        public Accomodation Accomodation { get; set; }

        private AccomodationCatalogSingleton()
        {
            // create an object instance of your business class
            AccomodationList = new List<Accomodation>() { new Accomodation(country: "France", city: "Marseille", imageUrl: "Cottage.jpg"),
             new Accomodation(country: "France", city: "Paris", imageUrl: "Cottage.jpg"),
             new Accomodation(country: "France", city: "Cannes", imageUrl: "Cottage.jpg"), };
        }

        // step 2:  this instance property check first if instance is not null ,
        // if its null then create an object instance otherwise return current instance 

        public static AccomodationCatalogSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AccomodationCatalogSingleton();
            }
            return Instance;
        }
        public void SetAccomodation(Accomodation accomodation)
        {
            Accomodation = accomodation;
        }
        public void DoAddAccomodation()
        { }
        public void DoDeleteAccomodation()
        { }
        public void DoRefreshAccomodation()
        { }
    }
}

