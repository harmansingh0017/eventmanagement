using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App1.Model;
using App1.Persistency;
using App1.View;
using App1.ViewModel;

namespace App1.Handler
{
    public class EventHandler
    {
        public EventViewModel EventViewModel { get; set; }
        
        public EventHandler(EventViewModel ev)
        {
            EventViewModel = ev;
        }

        public void LoadEvents()
        {
            EventViewModel.CatalogSingleton.LoadEventsAsync();
        }

        public void CreateEvent()
        {
            EventViewModel.CatalogSingleton.Add(new Event()
            {
                Name = EventViewModel.Name,
                Description = EventViewModel.Description,
                Place = EventViewModel.Place,
                Time = EventViewModel.Date
            });
        }

        public void RemoveEvent()
        {
            EventViewModel.CatalogSingleton.RemoveEvent(EventViewModel.SelectedEventIndex);
        }

        

    }
}
