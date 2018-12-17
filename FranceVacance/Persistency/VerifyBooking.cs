using FranceVacance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.ViewModel;

namespace FranceVacance.Persistency
{
    public static class VerifyBooking
    {
        public static bool VerifyNewBooking(Accommodation accommodation, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            if (DateTimeOffset.Compare(startDate, endDate) < 0) return true;
            MessageBox.Fail("The start date has to be earlier than the end date.");
            return false;

        }
    }
}
