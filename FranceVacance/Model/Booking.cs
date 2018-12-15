using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Model
{
    class Booking
    {
        public int Price { get; set; }
        public bool IsPaidFor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Accomodation Account { get; set; }
        public Account Accomodation { get; set; }

        public Booking(int price, DateTime startDate, DateTime endDate, Accomodation account, Account accomodation)
        {
            Price = price;
            IsPaidFor = false;
            StartDate = startDate;
            EndDate = endDate;
            Account = account;
            Accomodation = accomodation;
        }



    }
}
