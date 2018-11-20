using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FranceVacance.ViewModel
{
    static class MessageBox
    {
        public static async void Show(string message)
        {
            var dialog = new MessageDialog(message, "Something happened.");
            await dialog.ShowAsync();
        }
    }
}
