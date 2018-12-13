using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Model
{
    public class Booking
    {
        public int Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Accomodation Accomodation{ get ; set ; }

        public List<Booking> BookingList { get; set; }
        private static Booking _instance;

        public Booking( int price,bool IsPaid, DateTime Start, DateTime End,string Accomodation)
        {
            Price = price;
            IsPaid = false;
        }

        private Booking()
        {
        }
    }
}
