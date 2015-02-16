using System;
using System.Diagnostics;
using AdamS.Domain.Interfaces;

namespace AdamS.Domain
{
    public class EventLogLogger : ILogger
    {
        EventLog _log;
        public EventLogLogger()
        {
            // let's create our application log file
            if (!EventLog.SourceExists("ApplicationLog"))
            {
                EventLog.CreateEventSource("ApplicationLog", "SampleLog");
            }
        }

        private void DebugWriteLine(EventLogEntryType type, string message)
        {
            _log = new EventLog();
            _log.Source = "ApplicationLog";
            
            _log.WriteEntry(message, type);

            _log.Close();
        }

        public void Error(string message)
        {
            DebugWriteLine(EventLogEntryType.Error, "ERROR:  " + message);
        }

        public void Error(string format, params object[] args)
        {
            DebugWriteLine(EventLogEntryType.Error, "ERROR:  " + format);
        }

        public void Error(Exception ex, string message)
        {
            DebugWriteLine(EventLogEntryType.Error, "ERROR:  " + message + " Exception: " + ex);
            
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            DebugWriteLine(EventLogEntryType.Error, "ERROR:  " + format + " Exception: " + ex);
        }

        public void Info(string message)
        {
            DebugWriteLine(EventLogEntryType.Information, "INFO:  " + message);
        }

        public void Info(string format, params object[] args)
        {
            DebugWriteLine(EventLogEntryType.Information,"INFO:  " + format);
        }

        public void Info(Exception ex, string message)
        {
            DebugWriteLine(EventLogEntryType.Information, "INFO:  " + message + " Exception: " + ex);
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            DebugWriteLine(EventLogEntryType.Information, "INFO:  " + format + " Exception: " + ex);
        }      
    }
}