using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;

namespace FranceVacance.Persistency 
{
    class AccountCatalog
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public List<Account> Accounts { get; set; }

        public AccountCatalog()
        {
            Accounts = new List<Account>()
            {
                new Account("will@project.com", "strongpassword", "Will Blackney"),
                new Account("tomas@project.com", "weakpassword", "Tomas Vemola"),
                new Account("matus@project.com", "mediocrepassword", "Matus IDK")
            };
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public bool VerifyAccount(string email, string password)
        {
            if (
                //check if email is already in the list
                Accounts.Exists(a => a.Email == email) ||
                //check if password follows the rules
                password.Length < 8 ||
                !(password.Any(char.IsUpper)) ||
                !(password.Any(char.IsLower)) ||
                !(password.Any(char.IsSymbol))
                )
            {
                return false;
            }
            return true;
        }

        public void CreateAccount(string email, string password, string fullname)
        {
            if (VerifyAccount(email, password))
            {
                //create object
                //add object to list
            }
            else
            {
                //tell the user it's wrong
            }

        }
    }
}
