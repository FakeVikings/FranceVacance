using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;

namespace FranceVacance.Persistency 
{
    class AccountPersistency
    {
        private Account acc1;
        private List<Account> accounts = new List<Account>();

        //accounts.Add(acc1)
        //you cannot write it here because this is the class' body and there can be no logic here
        //you must write it in the method like this

        //testing

        public void AddAccount()
        {
            accounts.Add(acc1);
        }
    }
}
