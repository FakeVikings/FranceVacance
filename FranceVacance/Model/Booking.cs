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
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        //public Accomodation Country { get; set; }
        //public Account Accomodation { get; set; }

        public Booking(/*int price,*/ DateTimeOffset startDate, DateTimeOffset endDate)
        {
            //Price = price;
            IsPaidFor = false;
            StartDate = startDate;  
            EndDate = endDate;

            //startDate.ToString();
            //endDate.ToString();

        }


    }
}
