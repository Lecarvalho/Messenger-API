using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using MessengerApi.Business.Models;
using MessengerApi.Services.Configuration;

namespace MessengerApi.Services.Dispatchers
{
    public class EmailDispatcher : DispatcherBase
    {
        private EmailConfig _config;
        public EmailDispatcher(EmailConfig config)
        {
            _config = config;
        }

        public override async Task Send(MessageModel message, string appName)
        {
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient(_config.Smtp);

                mail.From = new MailAddress(_config.From);
                mail.To.Add(_config.To);
                mail.Subject = "Message from Messenger-API";
                mail.Body = message.Content;
                mail.Body += "<p>" + message.Date.ToShortDateString();
                mail.Body += "<br />" + message.User?.Name + "</p>";
                mail.Body += "<p>" + appName + "</p>";
                mail.IsBodyHtml = true;
                
                if (message.Image != null)
                    mail.Attachments.Add(new Attachment(message.Image.OpenReadStream(), message.Image.FileName));

                smtpServer.Port = _config.Port;
                smtpServer.UseDefaultCredentials = true;
                smtpServer.Credentials = new NetworkCredential(_config.Username, _config.Password);
                smtpServer.EnableSsl = true;

                await smtpServer.SendMailAsync(mail);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}