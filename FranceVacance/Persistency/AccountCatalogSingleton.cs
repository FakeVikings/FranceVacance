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
    public class AccountCatalogSingleton
    {
        public List<Account> AccountsList { get; set; }
        private static AccountCatalogSingleton _instance;

        private AccountCatalogSingleton()
        {
            AccountsList = new List<Account>() {new Account (fullname:"Tomas Vemola",email:"tomas@project.com",password:"Verystrongpassword1", admin:true)};
        }

        public static AccountCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountCatalogSingleton();
                }

                return _instance;
            }
        }

        private void AddAccount(Account account)
        {
            AccountsList.Add(account);
            MessageBox.Success("Account has been created.");
        }

        public void CreateAccount(string fullname, string email, string password)
        {
            if (VerifyAccount.VerifyNewAccount(fullname, email, password,  AccountsList))
            {
                Account account = new Account(fullname, email, password, admin: false) { Fullname = fullname, Email = email, Password = password };
                AddAccount(account);
            }
        }
    
        public void LogIn(string email, string password)
        {
            if (VerifyAccount.VerifyExistingAccount(email, password, AccountsList) != null)
            {
               // MessageBox.Success("You have logged in successfully.");
                Navigate.ActivateFrameNavigation(typeof(MainPage));
            }
            else
            {
              //  MessageBox.Fail("Login failed.");
            }
        }
    }
}
