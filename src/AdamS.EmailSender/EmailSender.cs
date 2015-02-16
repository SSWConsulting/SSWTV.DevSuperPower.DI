using AdamS.Domain.Interfaces;

namespace AdamS.EmailSender
{
    public class EmailSender : INotificationProvider
    {
        public bool Send(string destination, string subject, string body)
        {
            //todo: send an email
            return true;
        }
    }
}