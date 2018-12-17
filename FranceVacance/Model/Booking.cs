using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Model
{
    class Booking
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public bool IsPaidFor { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        //public Accommodation Country { get; set; }
        //public Account Accommodation { get; set; }

        public Booking(Accommodation accommodation, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            Price = (endDate - startDate).Days * accommodation.PricePerNight;
            accommodation.IsBooked = true;
            IsPaidFor = false;
            StartDate = startDate;  
            EndDate = endDate;
            ID = 1;
            ID++;

            //startDate.ToString();
            //endDate.ToString();

        }


    }
}
