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
    class MyBookingViewModel : NotifyViewModel
    {
        private string _country;
        private string _city;
        private int _price;
        private string _imageUrl;
        private ObservableCollection<Accommodation> _myBookedAList;
        public int SelectedIndex { get; } = 0;
        public RelayCommand GoMainPageCommand { get; set; }
        public BookingCatalogSingleton Singleton;
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
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
        public ObservableCollection<Accommodation> MyBookedAList
        {
            get { return _myBookedAList; }
            set
            {
                _myBookedAList = value;
                OnPropertyChanged(nameof(MyBookedAList));
            }
        }
        public MyBookingViewModel()
        {
            GoMainPageCommand = new RelayCommand(GoMainPage);
            Singleton = BookingCatalogSingleton.Instance;
          //  Country = Singleton.GetCountry();
          //  City = Singleton.GetCity();
           // ImageUrl = Singleton.GetImageUrl();
           // Price = Singleton.GetPrice();
        }
        public void GoMainPage()
        {
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
