namespace AdamS.StoreTemp.Models
{
    public interface INotificationProvider
    {
        bool Send(string destination, string subject, string message);
    }
  
    public class SmsSender : INotificationProvider
    {
        public bool Send(string destination, string subject, string body)
        {
            //todo: send 
            return true;
        }
    }
}