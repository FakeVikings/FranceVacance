using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Model
{
    public class Accommodation
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PricePerNight { get; set; }
        public string ImageUrl { get; set; }
        public bool IsBooked { get; set; }

        public Accommodation(string country, string city, int pricePerNight, string imageUrl)
        {
            Country = country;
            City = city;
            PricePerNight = pricePerNight;
            ImageUrl = imageUrl;
            IsBooked = false;
        }

        public Accommodation() { }

        public override string ToString()
        {
            return Country;
        }
       
    }
}
