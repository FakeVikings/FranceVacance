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
        private VerifyAccount _verifyAccount;

        private AccountCatalogSingleton()
        {
            AccountList = new List<Account>() {new Account (fullname:"Tomas Vemola",email:"tomas@project.com",password:"Verystrongpassword1")};
            _verifyAccount = new VerifyAccount();
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
        //public bool NullExeption(string fullname, string email, string password)
        //{
        //    if (fullname != null && email != null && password != null)
        //    {
        //        return true;
        //    }
        //    else{
        //        MessageBox.Fail("Please fill in all the columns.");
        //        return false;
        //    }
        //}
        //public bool VerifyAccount(string fullname, string email, string password)
        //{
        //    if (AccountList.Exists(a => a.Email == email))
        //    {
        //        MessageBox.Fail("This Email is already in use.");
        //        return false;
        //    }
        //    if (fullname.Length < 3)
        //    {
        //        MessageBox.Fail("Fullname must have more than 3 chars");
        //        return false;
        //    }
        //    if (!(email.Contains("@") && email.Contains(".")))
        //    {
        //        MessageBox.Fail("Email is not valid");
        //        return false;
        //    }
        //    if (password.Length < 8
        //        ||
        //        !(password.Any(char.IsUpper)) ||
        //        !(password.Any(char.IsLower)) ||
        //        !(password.Any(char.IsDigit)))
        //    {
        //        MessageBox.Fail("Password must have at least 8 characters, one uppercase letter, one lowercase letter and one number.");
        //        return false;
        //    }
        //    {
        //        return true;
        //    }
        //}
        public void CreateAccount(string fullname, string email, string password)
        {
            if (_verifyAccount.VerifyNewAccount(fullname, email, password, AccountList))
            {
                Account account = new Account(fullname, email, password) { Fullname = fullname, Email = email, Password = password };
                AddAccount(account);
            }
        }
        //public bool NullExeption1(string email, string password)
        //{
        //    if (email != null && password != null)
        //    {
        //        return true;

        //    }
        //    {
        //        MessageBox.Fail("Please fill both columns");
        //        return false;
        //    }
        //}
        //public Account LoginVerification(string email, string password)
        //{
        //    if (AccountList.Exists(a => a.Email == email))
        //    {
        //        var accountToLogIn = AccountList.Find(a => a.Email == email);
        //        if (accountToLogIn.Password == password)
        //        {
        //            return accountToLogIn;
        //        }

        //        return null;
        //    }

        //    return null;
        //}
    
        public void GainAccess(string email, string password)
        {
            if (_verifyAccount.VerifyExistingAccount(email, password, AccountList) != null)
            {
                LoginSuccessful();
            }
            else
            {
                MessageBox.Fail("Login failed.");
            }
        }
        public void LoginSuccessful()
        {
            MessageBox.Success("You have logged in successfully");
            Type type = typeof(MainPage);
            Navigate.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
