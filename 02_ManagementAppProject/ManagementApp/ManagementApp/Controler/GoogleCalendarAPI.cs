using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagementApp.Controler
{
    class GoogleCalendarAPI
    {
        private static readonly string ApplicationName = "Google Calendar API";
        private static UserCredential credential = null;
        private static CalendarService service = null;

        public static void AuthorizeAccount()
        {
            var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.ReadWrite);


            //Tworzenie połączenia z kontem
            string credPath = "token1.json";     //Miejsce w którym zapisane zostaną dane użytkownika
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            new string[] { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarReadonly }, //Zakres 
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true)).Result;


            //Tworzenie Google Calendar API service.
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

        }

        public static void AddEvent(string summary, DateTime startDate, DateTime endDate)
        {
            //Tworzenie nowego zadania i ustawianie własności
            Event newEvent = new Event();
            EventDateTime eventStartDate = new EventDateTime();
            EventDateTime eventEndDate = new EventDateTime();
            eventStartDate.DateTime = startDate;
            eventEndDate.DateTime = endDate;
            newEvent.Start = eventStartDate;
            newEvent.End = eventEndDate;
            newEvent.Summary = "MA-" + summary;


            //Zapis nowego wydarzenia do kalendarza - wymagane wcześniejsze połączenie z kontem google
            service.Events.Insert(newEvent, "primary").Execute();
            //Console.WriteLine("Event created: " + newEvent.HtmlLink);
        }

        public static void DeleteEvent()
        {
            // Definicja parametrów rządania
            EventsResource.ListRequest request = service.Events.List("primary");
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 1000;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // Listz wydarzeń
            Events events = request.Execute();

            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    if (eventItem.Summary[0] == 'M' && eventItem.Summary[1] == 'A' && eventItem.Summary[2] == '-')
                    {
                        service.Events.Delete("primary", eventItem.Id).Execute();
                    }
                }
            }

        }
    }
}
