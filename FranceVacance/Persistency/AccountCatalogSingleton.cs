using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using FranceVacance.Model;
using FranceVacance.ViewModel;

namespace FranceVacance.Persistency
{
    class AccountCatalogSingleton
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
            MessageBox.Show("Account has been created.");
        }
        public bool NullExeption(string fullname, string email, string password)
        {
            if (fullname != null && email != null && password != null)
            {
                VerifyAccount(fullname, email, password);
            }
            {
                MessageBox.Show1("Please fill in all the columns.");
                return false;
            }
        }
        public bool VerifyAccount(string fullname, string email, string password)
        {
            if (AccountList.Exists(a => a.Email == email))
            {
                MessageBox.Show("This Email is already in use.");
                return false;
            }
            if (fullname.Length < 3)
            {
                    MessageBox.Show1("Fullname must have more than 3 chars");
                    return false;
            }
            if (!(email.Contains("@") && email.Contains(".")))
                {
                    MessageBox.Show1("Email is not valid");
                    return false;
                }
            if (password.Length < 8
                ||
                !(password.Any(char.IsUpper)) ||
                !(password.Any(char.IsLower)) ||
                !(password.Any(char.IsDigit)))
            {
                MessageBox.Show1("Password must have at least 8 characters, one uppercase letter, one lowercase letter and one number.");
                return false;
            }
            {
                return true;

            }
        }

        public void CreateAccount(string fullname, string email, string password)
        {
            if (NullExeption(fullname, email, password))
            {
                Account account = new Account(fullname, email, password) { Fullname = fullname , Email= email,Password=password};
                AddAccount(account);
            }
        }
    }
}
