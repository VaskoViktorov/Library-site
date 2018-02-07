namespace Library.Web.Infrastructure.Extensions
{
    using Areas.LibraryBlog.Models.Events;
    using Areas.LibraryBlog.Models.Surveys;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class ObjToJsonConverterExtensions
    {
        public static bool CreateEventInJsonFile(object obj, string path)
        {
            string json = JsonConvert.SerializeObject(obj);

            var text = File.ReadAllText(path);

            if (text.Length < 2)
            {
                return false;
            }

            text = text.Remove(text.Length - 1);
            text = text + $",{Environment.NewLine}" + json + "]";

            File.WriteAllText(path, text);

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

            var text = string.Join($",{Environment.NewLine}", strings);
            text = "[" + text + "]";

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

        public static SurveyFormModel FindSurveyInJsonFile(string path, string id)
        {
            var survey = ListofSurveysInJsonFile(path);
            var currentSurvey = survey.Find(a => a.id == id);

            return currentSurvey;
        }

        public static List<SurveyFormModel> ListofSurveysInJsonFile(string path)
        {
            var text = File.ReadAllText(path);
            List<SurveyFormModel> surveys = JsonConvert.DeserializeObject<List<SurveyFormModel>>(text);

            return surveys;
        }

        public static bool EditSurveyInJsonFile(string path, SurveyFormModel eventForChange)
        {
            var surveys = ListofSurveysInJsonFile(path);
            var currentEvent = surveys.Find(a => a.id == eventForChange.id);

            if (currentEvent == null)
            {
                return false;
            }

            surveys.Remove(currentEvent);

            surveys.Add(eventForChange);

            List<string> strings = new List<string>();

            string json;

            foreach (var sr in surveys)
            {
                json = JsonConvert.SerializeObject(sr);
                strings.Add(json);
            }

            var text = string.Join($",{Environment.NewLine}", strings);
            text = "[" + text + "]";

            File.WriteAllText(path, text);

            return true;
        }
    }
}