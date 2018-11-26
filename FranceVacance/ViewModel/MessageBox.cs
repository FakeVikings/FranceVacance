﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FranceVacance.ViewModel
{
    static class MessageBox
    {
        public static async void Success(string message)
        {
            var dialog = new MessageDialog(message, " ");
            await dialog.ShowAsync();
        }
        public static async void Fail(string message)
        {
            var dialog = new MessageDialog(message,"An Error has occured");
            await dialog.ShowAsync();
        }
    }
}
