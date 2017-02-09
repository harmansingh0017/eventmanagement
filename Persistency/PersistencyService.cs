using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using App1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using App1.ViewModel;

namespace App1.Persistency
{
    public class PersistencyService
    {
        public ObservableCollection<Event> _theEvents; 
        private  static string eventsFileName = "events.txt";
        


        public static async void SerializeEventsFileAsync(string eventsJsonString, string eventsFileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(eventsFileName,CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, eventsJsonString);
        }
       
        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            var singleton = EventCatalogSingleton.getInstance();
            var json = JsonConvert.SerializeObject(singleton.list);
            SerializeEventsFileAsync(json, eventsFileName);

        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);

        }

        public static async Task<ObservableCollection<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(eventsFileName);
            if (eventsJsonString != null)
                return (ObservableCollection<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(ObservableCollection<Event>));
            return null;
        }


    }


}
