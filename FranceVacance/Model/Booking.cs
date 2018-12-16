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
        //public Accomodation Country { get; set; }
        // public Account Accomodation { get; set; }

        public Booking(int price, DateTime startDate, DateTime endDate)
        {
            Price = price;
            IsPaidFor = false;
            StartDate = startDate;  
            EndDate = endDate;

            startDate.ToString();
            endDate.ToString();

        }


    }
}
