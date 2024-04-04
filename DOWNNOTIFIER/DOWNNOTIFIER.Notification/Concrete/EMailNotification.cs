using DOWNNOTIFIER.Notification.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.Notification.Concrete
{
    public class EMailNotification : BaseNotification
    {
        private const string DEFAULT_HOST = "mail.kurumsaleposta.com";
        private const int DEFAULT_PORT = 587;
        private const string DEFAULT_USERNAME = "burak.kayabal@proceed.com.tr";
        private const string DEFAULT_PASSWORD = "Kayabal.Burak41";
        private const bool DEFAULT_ENABLE_SSL = false;
        private const string DEFAULT_SENDER = "error@proceed.com.tr";

        public override async Task SendNotification(Dictionary<string, object> parameters)
        {
            var jsonTo = parameters.FirstOrDefault(x => x.Key.Equals("TO")).Value.ToString();
            var stringMailPriority = parameters.FirstOrDefault(x => x.Key.Equals("MAILPRIORITY")).Value.ToString();

            var to = System.Text.Json.JsonSerializer.Deserialize<List<string>>(jsonTo);
            var mailPriority = (MailPriority)Enum.Parse(typeof(MailPriority), stringMailPriority);
            var from = parameters.FirstOrDefault(x => x.Key.Equals("FROM")).Value.ToString();
            var subject = parameters.FirstOrDefault(x => x.Key.Equals("SUBJECT")).Value.ToString();
            var body = parameters.FirstOrDefault(x => x.Key.Equals("BODY")).Value.ToString();
            

            using (var smtpClient = new SmtpClient(DEFAULT_HOST))
            {
                smtpClient.Port = DEFAULT_PORT;
                smtpClient.Credentials = new NetworkCredential(DEFAULT_USERNAME, DEFAULT_PASSWORD);
                smtpClient.EnableSsl = DEFAULT_ENABLE_SSL;

                using (var mailMessage = new MailMessage())
                {
                    foreach (var item in to)
                    {
                        mailMessage.To.Add(item);
                    }

                    mailMessage.From = new MailAddress(from);
                    mailMessage.Sender = new MailAddress(from);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.Priority = mailPriority;
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
                    mailMessage.IsBodyHtml = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
