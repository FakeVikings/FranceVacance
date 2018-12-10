using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace FranceVacance.Persistency
{
    class JsonFile<T> where T : class
    {
        private const string FileName = "data.json";
        private readonly CreationCollisionOption _option;
        private StorageFolder _folder;

        public JsonFile()
        {
            _option = CreationCollisionOption.OpenIfExists;
            _folder = ApplicationData.Current.LocalFolder; // application folder
        }

        // Serialization
        public async Task SaveAsync(ObservableCollection<T> data)
        {
            // Create File 
            var dataFile = await _folder.CreateFileAsync(FileName, _option);
            // Serialize object into Byte of Streams
            string dataJson = JsonConvert.SerializeObject(data);
            // Add data into file
            await FileIO.WriteTextAsync(dataFile, dataJson);
            MessageDialog msg = new MessageDialog("Data save successfully in the File");
            await msg.ShowAsync();
        }
        // Deserialization
        public async Task<ObservableCollection<T>> LoadAsync()
        {
            try
            {
                // Get file from folder
                StorageFile dataFile = await _folder.GetFileAsync(FileName);
                // Read data from file 
                string dataJson = await FileIO.ReadTextAsync(dataFile);
                // Deserialize : convert byte of stream into Objects
                return (dataJson != null) ? JsonConvert.DeserializeObject<ObservableCollection<T>>(dataJson) : new ObservableCollection<T>();
            }
            catch (Exception e)
            {
                MessageDialog msg = new MessageDialog("Error, File is not Exist");
                await SaveAsync(new ObservableCollection<T>());
                return new ObservableCollection<T>();
            }
        }
    }
}
