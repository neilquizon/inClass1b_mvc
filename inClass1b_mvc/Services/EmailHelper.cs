using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using thirdLab.Models;

namespace thirdLab.Services
{
    public class EmailHelper
    {
        private readonly EmailSettings _eSettings;

        public EmailHelper(EmailSettings _eSettings)
        {
            this._eSettings = _eSettings;
        }

        public bool SendEmail(string recipient, string subject)
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(_eSettings.FromEmail, _eSettings.DisplayName)

                };

                string toEmail = string.IsNullOrEmpty(recipient) ? _eSettings.ToEmail : recipient;
                mail.To.Add(new MailAddress(toEmail));

                foreach(string bcc in _eSettings.BccEmails)
                {
                    mail.To.Add(new MailAddress(bcc));
                }

                mail.Subject = subject;

                string text = "Plain text version of a message body";
                string html = @"<p>HTML version of a message body. </p>";
                mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text,
                null, MediaTypeNames.Text.Plain));
                mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html,
                null, MediaTypeNames.Text.Html));
                mail.Attachments.Add(new Attachment(@".//attachments//NeilQuizon.pdf"));
                mail.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient(_eSettings.Domain, _eSettings.Port);
                smtp.Credentials = new NetworkCredential(_eSettings.UsernameLogin, _eSettings.UsernamePassword);
                smtp.EnableSsl = false;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
