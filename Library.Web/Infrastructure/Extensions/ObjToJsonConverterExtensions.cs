using System.Collections.Generic;
using System.IO;
using System.Linq;
using Library.Web.Areas.LibraryBlog.Models.Events;

namespace Library.Web.Infrastructure.Extensions
{
    using System;
    using Newtonsoft.Json;

    public static class ObjToJsonConverterExtensions
    {
        public static bool CreateEventInJsonFile(object obj, string path)
        {
            string json = JsonConvert.SerializeObject(obj);

            var text = System.IO.File.ReadAllText(path);

            if (text.Length < 2)
            {
                return false;
            }

            text = text.Remove(text.Length - 1);
            text = text + $",{Environment.NewLine}" + json + "]";

            System.IO.File.WriteAllText(path, text);

            return true;
        }

        public static List<EventFormModel> ListofEventsInJsonFile(string path)
        {
            var text = File.ReadAllText(path);
            List<EventFormModel> events = JsonConvert.DeserializeObject<List<EventFormModel>>(text);
            return events;
        }

        public static EventFormModel FindEventInJsonFile(string path, string id)
        {
            var events = ListofEventsInJsonFile(path);
            var currentEvent = events.Find(a => a.id == id);
            
            return currentEvent;
        }

        public static bool EditEventInJsonFile(string path, EventFormModel eventForChange)
        {
            var events = ListofEventsInJsonFile(path);
            var currentEvent = events.Find(a => a.id == eventForChange.id);

            if (currentEvent == null)
            {
                return false;
            }
            events.Remove(currentEvent);
            
            events.Add(eventForChange);  
            
            List<string> strings = new List<string>();

            string json;
            foreach (var ev in events)
            {
                json = JsonConvert.SerializeObject(ev);
                strings.Add(json);
            }

            var text =string.Join($",{Environment.NewLine}", strings);
            text = "["+text+"]";

            File.WriteAllText(path, text);

            return true;
        }

        public static bool DeleteEventInJsonFile(string path, string id)
        {
            var events = ListofEventsInJsonFile(path);
            var currentEvent = events.Find(a => a.id == id);

            if (currentEvent == null)
            {
                return false;
            }
            events.Remove(currentEvent);
          
            List<string> strings = new List<string>();

            string json;
            foreach (var ev in events)
            {
                json = JsonConvert.SerializeObject(ev);
                strings.Add(json);
            }

            var text = string.Join($",{Environment.NewLine}", strings);
            text = "[" + text + "]";

            File.WriteAllText(path, text);

            return true;
        }
    }
}
