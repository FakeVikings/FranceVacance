using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Model
{
    public class Account
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Account(string fullname,string email,string password)
        {
            Fullname = fullname;
            Email = Email;
            Password = password;
        }
           
        public override string ToString()
        {
            return Fullname;
        }

    }
}
