using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdamS.Domain.Interfaces;

namespace AdamS.SimpleSMS
{
    public class SmsSender : INotificationProvider
    {
        public bool Send(string destination, string subject, string body)
        {
            //todo: send 
            return true;
        }
    }
}
