using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;
using FranceVacance.Command;
using FranceVacance.View;
using FranceVacance.Persistency;

namespace FranceVacance.ViewModel
{
    class LoginViewModel : NotifyViewModel
    {
            public RelayCommand GoCAVCommand { get; set; }
            public AccountCatalogSingleton Singleton;
            public string Fullname { get; set; }
            public string Email { get; set; }
            public LoginViewModel()
            {
                GoCAVCommand = new RelayCommand(GoCAV);
                Singleton = AccountCatalogSingleton.Instance;

            }
            public void GoCAV()
            {
                Type type = typeof(CreateAccountView);
                Navigate.ActivateFrameNavigation(type);

            }
    }
}
