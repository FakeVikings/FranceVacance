﻿using FranceVacance.Command;
using FranceVacance.Model;
using FranceVacance.Persistency;
using FranceVacance.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Printing3D;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FranceVacance.ViewModel
{
    class MainPageViewModel : NotifyViewModel
    {

        private string _country;
        private string _city;
        private int _price;
        private string _imageUrl;

        public int SelectedIndex { get; } = 0; // 0 index
        public ObservableCollection<Accomodation> AccomodationList { get; set; }
        public RelayCommand AddAccomodationCommand { get; set; }
        public RelayCommand UpdateAccomodationCommand { get; set; }
        public RelayCommand DeleteAccomodationCommand { get; set; }
        public RelayCommand RefreshAccomodationCommand { get; set; }
        public RelayCommand GoApCommand { get; set; }

        // Add Accomodation
        public Accomodation AddAccomodation { get; set; }


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


        public readonly AccomodationCatalogSingleton AccomodationCatalogSingleton;
        private Accomodation _selectedItemAccomodation;
        public RelayCommand GoLoginViewCommand { get; set; }
        public RelayCommand GoAPCommand { get; set; }

        public Accomodation SelectedItemAccomodation
        {
            get => _selectedItemAccomodation;
            set
            {
                _selectedItemAccomodation = value;
                OnPropertyChanged(nameof(SelectedItemAccomodation));
            }
        }
        // public readonly Navigate FrameNavigate;

        private JsonFile<Accomodation> _filePersistency;


        public MainPageViewModel()
        {
            // Data Persistency 
            AccomodationList = DataCollectionClass.AccomodationList();

            RunAsyncLoadData();


            _filePersistency = new JsonFile<Accomodation>();
            AddAccomodationCommand = new RelayCommand(DoAddAccomodation);
            UpdateAccomodationCommand = new RelayCommand(DoUpdateAccomodation);
            DeleteAccomodationCommand = new RelayCommand(DoDeleteAccomodation);
            RefreshAccomodationCommand = new RelayCommand(DoRefreshAccomodation);
            AddAccomodation = new Accomodation();
            GoLoginViewCommand = new RelayCommand(GoLoginView);

            AccomodationCatalogSingleton = AccomodationCatalogSingleton.GetInstance();
        }

        public async void DoAddAccomodation()
        {
          
                string img = "../Assets/" + AddAccomodation.ImageUrl + ".jpg";
                AddAccomodation.ImageUrl = img;
                AccomodationList.Add(AddAccomodation);
                await SaveAsyncMethod(AccomodationList);
            
           

        }

        public void DoUpdateAccomodation()
        {
        }

        public void DoDeleteAccomodation()
        {
            AccomodationList.Remove(SelectedItemAccomodation);
        }

        public void DoRefreshAccomodation()
        {
        }


        public void GoLoginView()
        {
            Type type = typeof(LoginView);
            Navigate.ActivateFrameNavigation(typeof(LoginView));
        }
        
        public void GoAP()
        {
           // UserSingleton.SetAccomodation(SelectedItemAccomodation);

            Type type = typeof(AccomodationPage);
            Navigate.ActivateFrameNavigation(type);
        }

        public async void RunAsyncLoadData()
        {
           // AccomodationList = await _filePersistency.LoadAsync();
        }
        // Load data from file
        public async Task<ObservableCollection<Accomodation>> LoadAsyncMethod()
        {
            return await _filePersistency.LoadAsync();
        }

        // Save data into file 
        public async Task SaveAsyncMethod(ObservableCollection<Accomodation> accomodations)
        {
            await _filePersistency.SaveAsync(accomodations);
        }

        // Handling problems

        
    }
}
