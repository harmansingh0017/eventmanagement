using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }

        public Event()
        {
        }

        public override string ToString()
        {
            return string.Format("The {0} event(ID: {1}) will take place on {2}, at {3}. Description: {4}", Name, ID,
                Time, Place, Description);
        }
    }
}
