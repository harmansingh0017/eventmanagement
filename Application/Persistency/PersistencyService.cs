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
            EventCatalogSingleton singleton = new EventCatalogSingleton();
            var json = JsonConvert.SerializeObject(singleton.list);
            SerializeEventsFileAsync(json, eventsFileName);

        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            Task<string> t = new Task<string>(() =>
            {
                return File.ReadAllText(fileName);
            });
            t.Start();
            string fin = t.ToString();
            ObservableCollection<Event> outObject = JsonConvert.DeserializeObject<ObservableCollection<Event>>(fin);
            
            return await t;
           
        }

        public static Task<List<Event>> LoadEventsFromJsonAsync()
        {
            DeSerializeEventsFileAsync(eventsFileName);
            return null;
        }

        //Removing the events


        //public static async Task<List<Event>> LoadEventsFromJsonAsync()
        //{

        //}

        //public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        //{
        //    string json = File.ReadAllText(fileName);
        //    JsonSerializer serializer = new JsonSerializer();
        //    var ev = serializer.Deserialize<ObservableCollection<Event>>();
        //    return json;
        //}
        //public async Task<ObservableCollection<Event>> LoadEvents()
        //{
        //    using (StreamReader file = File.OpenText(eventsFileName)
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        Event event = (event) serializer.Deserialize(file, typeof(Event));
        //    }
        //}

        //public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        //{
        //    //using (StreamReader file = File.OpenText(@"../Persistency/serialized.json"))
        //    //{
        //    //    JsonSerializer serializer = new JsonSerializer();
        //    //    Event event = (Event)serializer.Deserialize(file, typeof(Event));
        //}
    }


}
