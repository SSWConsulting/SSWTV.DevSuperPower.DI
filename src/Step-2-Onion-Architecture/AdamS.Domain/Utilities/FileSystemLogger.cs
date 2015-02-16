using System;
using AdamS.Domain.Interfaces;

namespace AdamS.Domain
{
    public class FileSystemLogger : ILogger
    {


        public string GetTempPath()
        {
            string path = System.Environment.GetEnvironmentVariable("TEMP");
            if (!path.EndsWith("\\")) path += "\\";
            return path;
        }

        private void WriteToLog(string msg)
        {
            System.IO.StreamWriter sw = System.IO.File.AppendText(
                GetTempPath() + "LogFile.txt");
            try
            {
                string logLine = System.String.Format(
                    "{0:G}: {1}.", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }



        public void Error(string message)
        {
            WriteToLog("ERROR:  " + message);
        }

        public void Error(string format, params object[] args)
        {
            WriteToLog("ERROR:  " + format);
        }

        public void Error(Exception ex, string message)
        {
            WriteToLog("ERROR:  " + message);
            WriteToLog(ex.ToString());
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            WriteToLog("ERROR:  " + format);
            WriteToLog(ex.ToString());
        }

        public void Info(string message)
        {
            WriteToLog("INFO:  " + message);
        }

        public void Info(string format, params object[] args)
        {
            WriteToLog("INFO:  " + format);
        }

        public void Info(Exception ex, string message)
        {
            WriteToLog("INFO:  " + message);
            WriteToLog(ex.ToString());
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            WriteToLog("INFO:  " + format);
            WriteToLog(ex.ToString());
        }
    }
}