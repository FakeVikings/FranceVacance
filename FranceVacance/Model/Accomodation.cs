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
        public string ImageUrl { get; set; }

        public Accomodation(string country, string city, string imageUrl)
        {
            Country = country;
            City = city;
            ImageUrl = imageUrl;
        }

        public Accomodation()
        {
        }

        public string GetCountry()
        {
            return Country;
        }
        public string GetCity()
        {
            return City;
        }
        public string GetImageUrl()
        {
            return ImageUrl;

        }
    }
}
