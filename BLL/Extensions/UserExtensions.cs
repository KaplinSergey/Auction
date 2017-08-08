using System;
using System.Net.Mail;
using System.Net;
using BLL.Interfaces.Entities;
using NLog;

namespace BLL.Extensions
{
    public static class UserExtensions
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public static void SendMessage(this UserEntity user, string mailSubject, string mailBody)
        {
            if (user==null)
            {
                throw new ArgumentNullException("user");
            }

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("myauctionproject1@gmail.com", "password110123");

            MailMessage mail = new MailMessage("myauctionproject1@gmail.com", user.Email);
            mail.Subject = mailSubject;
            mail.Body = mailBody;

            try
            {
                smtp.Send(mail);
            }
            catch (SmtpException e)
            {
                _logger.Error("BLL => When SendMessage method try to send mail to {0}, error message - {1}, stack trace - {2}", user.Email, e.Message, e.StackTrace);
                throw;
            }

        }
    }
}
