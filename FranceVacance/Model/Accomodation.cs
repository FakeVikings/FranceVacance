using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Model
{
    public class Accomodation
    {

        public string Country { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }

        public Accomodation(string country, string city, int price, string imageUrl)
        {
            Country = country;
            City = city;
            Price = price;
            ImageUrl = imageUrl;
            
        }
        public Accomodation() { }

        public override string ToString()
        {
            return Country;
        }
    }
}
