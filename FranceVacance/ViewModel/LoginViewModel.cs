﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;
using FranceVacance.Command;
using FranceVacance.View;

namespace FranceVacance.ViewModel
{
    class LoginViewModel : NotifyViewModel
    {
            public RelayCommand GoCAVCommand { get; set; }
            public FrameNavigate FrameNavigate { get; set; }
            public Singleton Singleton;
            public string Fullname { get; set; }
            public string Email { get; set; }
            public LoginViewModel()
            {
                FrameNavigate = new FrameNavigate();
                GoCAVCommand = new RelayCommand(GoCAV);
                Singleton = Singleton.GetInstance();
                Fullname = Singleton.GetFullname();

            }
            public void GoCAV()
            {
                Type type = typeof(CreateAccountView);
                FrameNavigate.ActivateFrameNavigation(type);

            }
    }
}
