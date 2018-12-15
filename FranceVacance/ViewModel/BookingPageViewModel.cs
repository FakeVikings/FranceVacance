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
            GoMainPageCommand = new RelayCommand(GoMainPage);
        }



        public void GoMainPage()
        {
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
