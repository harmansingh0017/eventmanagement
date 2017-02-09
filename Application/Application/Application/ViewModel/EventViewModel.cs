using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App1.Annotations;
using App1.Common;
using App1.Handler;
using App1.Model;


namespace App1.ViewModel
{
    public class EventViewModel: INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public EventCatalogSingleton CatalogSingleton {
            get {return EventCatalogSingleton.getInstance(); }
            set {} }
        public Handler.EventHandler EventHandler { get; set; }
        //public Event Event { get; set; }
        //   private Event _selectedEvent { get; set; }
        public int SelectedEventIndex
        {
            get { return _selectedEventIndex; }
            set
            {
                _selectedEventIndex = value;
                OnPropertyChanged(nameof(SelectedEventIndex));
            }
        }


        public EventViewModel()
        
        {
          
          EventHandler = new Handler.EventHandler(this);
          //_createEventCommand = new RelayCommand(EventHandler.CreateEvent);
          CreateEvent = new RelayCommand(EventHandler.CreateEvent);
          //RemoveEvent = new RelayCommand(EventHandler.RemoveEvent);
          _deleteEventCommand = new RelayCommand(EventHandler.RemoveEvent);

        }

        private ICommand _deleteEventCommand;
        private int _selectedEventIndex;

        public ICommand DeleteEventCommand
        {
            get { return _deleteEventCommand;}
            set
            {
                _deleteEventCommand = value; 
            //    OnPropertyChanged(nameof(DeleteEventCommand));
            }
        }

       
        public RelayCommand CreateEvent { get; set; }

        //public RelayCommand RemoveEvent { get; set; }
        //public RelayCommand CreateEventCommand
        //{
        //    get
        //    {
        //        return _createEventCommand;
        //    }
        //    set
        //    {
        //        _createEventCommand = value;
        //        _createEventCommand = new RelayCommand(EventHandler.CreateEvent);
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
