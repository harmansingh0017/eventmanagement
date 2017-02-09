using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using App1.Common;
using App1.Persistency;
using App1.ViewModel;

namespace App1.Model
{
    public sealed class EventCatalogSingleton
    {
        private static volatile EventCatalogSingleton instance = null;
        private static object syncRoot = new Object();
        private PersistencyService _serialize;
        
        //public EventViewModel Event { get; set; }
        public ObservableCollection<Event> list { get; private set; }

        public EventCatalogSingleton()
        {
            _serialize = new PersistencyService();
      
            list = new ObservableCollection<Event>()
            {
             new Event()
             {
                 Time = new DateTime(2017, 1, 2),
                 Description = "Something important to be done!",
                 ID=001,
                 Name="FirstEvent",
                 Place="Kobenhavn"
                 
             },
             new Event()
             {
                 Time = new DateTime(2017, 1, 3),
                 Description = "Something important to be done, too!",
                 ID=002,
                 Name="SecondEvent",
                 Place="Roskilde"

             }
            };
        }

        public static EventCatalogSingleton getInstance()
        {
            if (instance != null) return instance;
            lock (syncRoot)
            {
                if (instance == null)
                {
                    instance = new EventCatalogSingleton();
                }
            }
            return instance;
            
        }

        public void Add(Event newEvent)
        {
            list.Add(newEvent);
            PersistencyService.SaveEventsAsJsonAsync(newEvent);
        }

        public void RemoveEvent(int SelectedEvent)
        {
            list.RemoveAt(SelectedEvent);
        }


        public async Task LoadEventsAsync()
        {
          

        }
    }
}
