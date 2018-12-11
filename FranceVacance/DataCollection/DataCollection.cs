using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;

namespace FranceVacance
{
    class DataCollectionClass
    {
        public static ObservableCollection<Accomodation> AccomodationList()
        {
            return new ObservableCollection<Accomodation>()
            {
                new Accomodation("Paris", "France", 60, "../Assets/cottage.jpg"),
                new Accomodation("Berlin", "Germany", 90, "../Assets/cottage.jpg"),
                new Accomodation("Prague", "Czech republic", 40, "../Assets/cottage.jpg"),
                new Accomodation("Bratislava", "Bratislava", 30, "../Assets/cottage.jpg"),



            };
        }
    }
}
