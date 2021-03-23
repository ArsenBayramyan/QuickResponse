using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuickResponse.Core
{
    public class EmailSender
    {
        public static void SendEmailMessage(string userToEmail, string message,string subject)
        {
            var senderEmail = new MailAddress("arsen1997b@mail.ru", subject);
            var receiverEmail = new MailAddress($"arsen.bayramyan1997@gmail.com", subject);
            var password = "*****";
            var smtp = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = message
            })
            {
                smtp.Send(mess);
            }
        }
    }
}
