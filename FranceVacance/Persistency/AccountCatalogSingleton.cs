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
        public List<Account> AccountList { get; set; }
        private static AccountCatalogSingleton _instance;

        private AccountCatalogSingleton()
        {
            AccountList = new List<Account>() {new Account (fullname:"Tomas Vemola",email:"tomas@project.com",password:"Verystrongpassword1")};
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

        public void AddAccount(Account account)
        {
            AccountList.Add(account);
            MessageBox.Success("Account has been created.");
        }
        public bool NullExeption(string fullname, string email, string password)
        {
            if (fullname != null && email != null && password != null)
            {
                return true;
            }
            else{
                MessageBox.Fail("Please fill in all the columns.");
                return false;
            }
        }
        public bool VerifyAccount(string fullname, string email, string password)
        {
            if (AccountList.Exists(a => a.Email == email))
            {
                MessageBox.Fail("This Email is already in use.");
                return false;
            }
            if (fullname.Length < 3)
            {
                MessageBox.Fail("Fullname must have more than 3 chars");
                return false;
            }
            if (!(email.Contains("@") && email.Contains(".")))
            {
                MessageBox.Fail("Email is not valid");
                return false;
            }
            if (password.Length < 8
                ||
                !(password.Any(char.IsUpper)) ||
                !(password.Any(char.IsLower)) ||
                !(password.Any(char.IsDigit)))
            {
                MessageBox.Fail("Password must have at least 8 characters, one uppercase letter, one lowercase letter and one number.");
                return false;
            }
            {
                return true;
            }
        }
        public void CreateAccount(string fullname, string email, string password)
        {
            if (NullExeption(fullname, email, password) && VerifyAccount(fullname, email, password))
            {
                Account account = new Account(fullname, email, password) { Fullname = fullname, Email = email, Password = password };
                AddAccount(account);
            }
        }
        public bool NullExeption1(string email, string password)
        {
            if (email != null && password != null)
            {
                return true;

            }
            {
                MessageBox.Fail("Please fill both columns");
                return false;
            }
        }
        public Account LoginVerification(string email, string password)
        {
            if (AccountList.Exists(a => a.Email == email))
            {
                return AccountList.Find(a => a.Email == email); 
            }
            else
            {
                return null;
            }

            //if (AccountList.Exists(A => A.Email != email))
            //{
            //    MessageBox.Fail("You are not registered or it has mistake.");
            //    return false;
            //}
            //if (AccountList.Exists(p => p.Password != password))
            //{
            //    MessageBox.Fail("You have typed wrong password");
            //    return false;
            //}
            //return true;
        }
        public void GainAccess(string email, string password)
        {
            if (LoginVerification(email, password) != null)
            {
                LoginSuccessfull();
            }
            else
            {
                MessageBox.Fail("Login failed.");
            }
        }
        public void LoginSuccessfull()
        {
            MessageBox.Success("You have logged in successfully");
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
