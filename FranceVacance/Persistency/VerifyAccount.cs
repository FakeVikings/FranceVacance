using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;
using FranceVacance.ViewModel;

namespace FranceVacance.Persistency
{
    class VerifyAccount
    {
        private bool IsInputEmpty(string fullname, string email, string password)
        {
            return fullname == null || email == null || password == null;
        }

        public bool VerifyNewAccount(string fullname, string email, string password, List<Account> accountList)
        {
            if (IsInputEmpty(fullname, email, password))
            {
                MessageBox.Fail("Please fill in all boxes.");
                return false;
            }
            if (accountList.Exists(a => a.Email == email))
            {
                MessageBox.Fail("This email is already in use.");
                return false;
            }

            if (fullname.Length < 3)
            {
                MessageBox.Fail("Fullname must have more than 3 characters.");
                return false;
            }

            if (!(email.Contains("@") && email.Contains(".")))
            {
                MessageBox.Fail("Email must contain \"@\" and \".\"");
                return false;
            }

            if (
                password.Length < 8
                || !(password.Any(char.IsUpper))
                || !(password.Any(char.IsLower))
                || !(password.Any(char.IsDigit))
            )
            {
                MessageBox.Fail("Password must have at least 8 characters, one uppercase letter, one lowercase letter and one number.");
                return false;
            }

            return true;
        }

        public Account VerifyExistingAccount(string email, string password, List<Account> accountList)
        {
            if (accountList.Exists(a => a.Email == email))
            {
                var accountToLogIn = accountList.Find(a => a.Email == email);
                if (accountToLogIn.Password == password)
                {
                    return accountToLogIn;
                }

                return null;
            }

            return null;
        }
    }
}
