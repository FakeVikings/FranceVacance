using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Persistency;
using FranceVacance.Model;
using FranceVacance.ViewModel;
using System.Collections.ObjectModel;

namespace FranceVacance.Persistency
{
    public class LoginVerify
    {
        public List<Account> AccountList { get; set; }
        public bool NullExeption( string email, string password)
        {
            if (email != null && password != null)
            {
                return true;
            }
            else
            {
                MessageBox.Fail("Please fill in all the columns.");
                return false;
            }
        }
        public bool LoginVerification(string email, string password)
        {
            if (AccountList.Exists(a => a.Email != email))
            {
                MessageBox.Fail("You are not registered.");
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
                !(password.Any(char.IsDigit)) || (AccountList.Exists(p=> p.Password != password)))
            {
                MessageBox.Fail("You have typed wrong password");
                return false;
            }
            {
                return true;
            }
        }
        //public void GainAccess(string email, string password)
        //{
        //    if (LoginVerification(email, password))
        //    {
        //        LoginViewModel.LoginSuccessfull(email, password);
        //    }
        //}

    }
}
