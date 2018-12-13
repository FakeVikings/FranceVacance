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
        public DateTime Start;
        public DateTime End;
        private string _imageUrl;
        public object Singleton { get; set; }
        public void BookA(DateTime Start, DateTime End)
        {

        }

        public RelayCommand GoMainPageCommand { get; set; }
        private ObservableCollection<Accomodation> _myBookedAList;

        public BookingPageViewModel()
        {
        //    Singleton = BookedASingleton.GetInstance();
        ////    ImageUrl = Singleton.GetImageUrl();
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
