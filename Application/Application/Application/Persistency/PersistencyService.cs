using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using App1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FileAttributes = System.IO.FileAttributes;

namespace App1.Persistency
{
    public class PersistencyService
    {
        private ObservableCollection<Event> _theEvents; 
        private  static string eventsFileName = @"C:\Users\Cristian Patras\Desktop\Application\Application\Application\Application\Events.json";

        public static async void SaveEventsAsJsonAsync(Event events)
        {
           // StorageFolder localFolder = ApplicationData.Current.LocalFolder;
           // StorageFile file = await localFolder.CreateFileAsync(eventsFileName, CreationCollisionOption.ReplaceExisting);
            EventCatalogSingleton singleton = new EventCatalogSingleton();



            await Task.Run(() =>
            {
                Task.Yield();
                string directory = Directory.GetCurrentDirectory();
                var json = JsonConvert.SerializeObject(singleton.list);
                File.WriteAllText( directory, json);

            });
        }

        //public async Task<ObservableCollection<Event>> LoadEvents()
        //{
        //    string json = eventsFileName;
        //    JsonConvert.DeserializeObject<Event>(json);
            
        //    return null;
        //}
        //public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        //{
        //    using (StreamReader file = File.OpenText(@"../Persistency/serialized.json"))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        Event event = (Event)serializer.Deserialize(file, typeof(Event));
        //    }
        //}


    }
}
