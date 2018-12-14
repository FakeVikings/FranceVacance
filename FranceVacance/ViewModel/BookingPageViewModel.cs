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
    class BookingPageViewModel : NotifyViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        private string _imageUrl {get; set;}
        public bool BookAccommodation(DateTime Start, DateTime End)
        {
            if (Start == null || End == null)
            {
                
            }
            {

                MessageBox.Fail("You haven't set the date");
                return false;
            }
        }

        public RelayCommand GoMainPageCommand { get; set; }
        public AccommodationCatalogSingleton Singleton;

        public BookingPageViewModel()
        {
            Singleton = AccommodationCatalogSingleton.GetInstance();
            City = Singleton.GetCity();
            ImageUrl = Singleton.GetImageUrl();
            Price = Singleton.GetPrice();
            Country = Singleton.GetCountry();
            GoMainPageCommand = new RelayCommand(GoMainPage);
        }




        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged("ImageUrl");
            }
        }
        public void GoMainPage()
        {
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
