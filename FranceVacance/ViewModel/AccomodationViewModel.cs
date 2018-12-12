using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranceVacance.Model;
using System.Threading.Tasks;
using FranceVacance.Command;
using FranceVacance.Persistency;
using FranceVacance.View;

namespace FranceVacance.ViewModel
{
    class AccomodationViewModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public RelayCommand GoMainPageCommand { get; set; }


        public AccommodationCatalogSingleton Singleton;

        public AccomodationViewModel()
        {
            Singleton = AccommodationCatalogSingleton.GetInstance();
            //Retrieve the object instance from the Global Instance
            Country = Singleton.GetCountry();
            City = Singleton.GetCity();
            ImageUrl = Singleton.GetImageUrl();
            Price = Singleton.GetPrice();
            GoMainPageCommand = new RelayCommand(GoMainPage);

        }

        public void GoMainPage()
        {
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
