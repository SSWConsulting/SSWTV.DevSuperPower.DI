using System;
using System.Net.Mail;
using System.Threading.Tasks;
using AdamS.StoreTemp.Models.Common;

namespace AdamS.OnlineStore.Models
{
    //note: Email sending should be done Async, but this adds complexity to the demo
    public class EmailSender
    {
        public bool Send(string destination, string subject, string body)
        {
            //TODO: load from config
            string from = "admin@mycompany.com.au";
            string mailServer = "mail.mycompany.com";
            string mailServerUserName = "bob@mycompany.com";
            string mailServerPassword = "p@ssw0rd";

            if (!destination.IsValidEmailAddress())
            {
                return false;
            }

            try
            {
                var email = new MailMessage(from, destination)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true

                };

                using (var client = new SmtpClient())
                {
                    client.Host = mailServer;
                    client.Port = 587;
                    client.EnableSsl = false;

                    client.Credentials = new System.Net.NetworkCredential(
                        mailServerUserName, mailServerPassword);
                    //client.UseDefaultCredentials = true;

                    //todo: uncomment to enable sending
                    //client.Send(email);
                }

                return true;

            }
            catch 
            {
                //TODO: log errors
                return false;
            }
        }
    }
}