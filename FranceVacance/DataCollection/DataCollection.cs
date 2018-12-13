using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using FranceVacance.Model;

namespace FranceVacance
{
    class DataCollectionClass
    {
        public static StorageFolder folder = ApplicationData.Current.LocalFolder;
        public static StorageFile accomodationsFile;
        public static StorageFile accountfile;

        public static List<Accomodation> AccomodationList { get; set; }
        public static ObservableCollection<Accomodation> AccomodationListM()
        {
            return new ObservableCollection<Accomodation>()
            {
                new Accomodation("Paris", "France", 60, "../Assets/cottage.jpg"),
                new Accomodation("Berlin", "Germany", 90, "../Assets/cottage.jpg"),
                new Accomodation("Prague", "Czech republic", 40, "../Assets/cottage.jpg"),
                new Accomodation("Bratislava", "Bratislava", 30, "../Assets/cottage.jpg"),



            };
        }

        public static List<Account> AccountList { get; set; }

        public static async void SaveFiles()
        {
            
            string jsonAccs = JsonConvert.SerializeObject(AccountList, Formatting.Indented);
            accountfile = await folder.CreateFileAsync("accounts.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(accountfile, jsonAccs);
            string jsonaccomodation = JsonConvert.SerializeObject(AccomodationList, Formatting.Indented);
            accomodationsFile = await folder.CreateFileAsync("accomodations.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(accomodationsFile, jsonaccomodation);
        }

        public static async void ReadFiles()
        {
            AccountList = new List<Account>();
            AccomodationList = new List<Accomodation>();
            accountfile = await folder.CreateFileAsync("accounts.json", CreationCollisionOption.OpenIfExists);
            accomodationsFile =
                await folder.CreateFileAsync("accomodations.json", CreationCollisionOption.OpenIfExists);
            try
            {

                string jsontemp = await FileIO.ReadTextAsync(accomodationsFile);
                AccomodationList = JsonConvert.DeserializeObject<List<Accomodation>>(jsontemp);
                jsontemp = await FileIO.ReadTextAsync(accountfile);
                AccountList = JsonConvert.DeserializeObject<List<Account>>(jsontemp);
            }
            catch (Exception e)
            {

            }
        }


    }

    

    }
    
