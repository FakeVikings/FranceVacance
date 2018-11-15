﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.ViewModel;
using FranceVacance.Model;
using FranceVacance.Persistency;

namespace FranceVacance.ViewModel
{
    class AccountViewModel : NotifyChangePropertyClass
    {
        // public RelayCommand AddNewUser { get; set; }

        public AccountPersistency ac;
        private ObservableCollection<Account> _list;
        private string _email;
        private string _password;
        private string _fullname;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }

        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }

        }

        public string FullName
        {
            get { return _fullname; }
            set
            {
                _fullname = value;
                OnPropertyChanged("FullName");
            }
        }

        public ObservableCollection<Account> LIST
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged("LIST");
            }
        }

        private void AddAccount()
        {
            ac.CreateAccount(Email, Password, FullName);

            Email = "";
            Password = "";
            FullName = "";

            LIST = new ObservableCollection<Account>(ac.CreateAccount());
        }
    }

}
