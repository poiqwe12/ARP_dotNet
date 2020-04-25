using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace ManagementApp.Controler
{
    static class DiagnosticDictionary
    {
        static string applicationName = "ManagementApplication";
        static public string ApplicationName
        {
            get { return applicationName; }
            set
            {
                applicationName = value;
            }
        }

        static private bool CreateEventSourceIfNoExiste(string sourceName)
        {
            bool IsSourceExists;
            try
            {

                IsSourceExists = EventLog.SourceExists(sourceName);
                if (!IsSourceExists)
                {   // Jeśli źródło nie istnieje to je utwórz
                    EventLog.CreateEventSource(sourceName, "Application");
                }
            }
            catch (SecurityException)
            {
                sourceName = "SecurityException";
                return false;
            }
            return true;
        }

        //Zapisywanie
        public static void WriteMessage(string message)
        {
            if (CreateEventSourceIfNoExiste(applicationName))
            {
                EventLog.WriteEntry(applicationName, message, EventLogEntryType.Information);
            }
        }

        //Odczytywanie
        static public List<EventLogEntry> ReedMessage(string logName, int quontityOfMessage)
        {

            EventLog log = new EventLog(logName);
            List<EventLogEntry> messageList = new List<EventLogEntry>();
            for (int i = log.Entries.Count - 1; i >= log.Entries.Count - quontityOfMessage; i--)
            {
                messageList.Add(log.Entries[i]);
            }

            return messageList;
        }

    }
}
