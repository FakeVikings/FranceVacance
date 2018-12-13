using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;

namespace FranceVacance.Persistency
{
    static class Session
    {
        public static Account LogedInUser { get; set; }
    }
}
