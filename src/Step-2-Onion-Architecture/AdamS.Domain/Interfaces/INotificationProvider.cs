namespace AdamS.Domain.Interfaces
{
    public interface INotificationProvider
    {
        bool Send(string destination, string subject, string message);
    }
    
}