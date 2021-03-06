﻿using System;
using System.Diagnostics;
using AdamS.Domain.Interfaces;

namespace AdamS.Domain
{
    using System.Diagnostics;

    using System.IO;


    public class DebugLogger : ILogger
    {
        public void Error(string message)
        {
            Debug.WriteLine("ERROR:  " + message);
        }

        public void Error(string format, params object[] args)
        {
            Debug.WriteLine("ERROR:  " + format, args);
        }

        public void Error(Exception ex, string message)
        {
            Debug.WriteLine("ERROR:  " + message);
            Debug.WriteLine(ex.ToString());
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            Debug.WriteLine("ERROR:  " + format, args);
            Debug.WriteLine(ex.ToString());
        }

        public void Info(string message)
        {
            Debug.WriteLine("INFO:  " + message);
        }

        public void Info(string format, params object[] args)
        {
            Debug.WriteLine("INFO:  " + format, args);
        }

        public void Info(Exception ex, string message)
        {
            Debug.WriteLine("INFO:  " + message);
            Debug.WriteLine(ex.ToString());
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            Debug.WriteLine("INFO:  " + format, args);
            Debug.WriteLine(ex.ToString());
        }
    }
}