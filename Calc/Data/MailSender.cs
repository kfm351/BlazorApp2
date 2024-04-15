using System.Net.Mail;
using System.Net;

namespace Calc.Data
{
    public static class MailSender
    {
        public static void SendMail(string receiver, string messageText)
        {
            MailAddress fromM = new MailAddress("potalon.pechkin@mail.ru", "C#");
            MailAddress toM = new MailAddress(receiver);

            using (MailMessage message = new MailMessage(fromM, toM))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                message.Subject = "New Message!"; 
                message.Body = messageText; 

                smtpClient.Host = "smtp.mail.ru";
                smtpClient.Port = 25;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromM.Address, "T6qCnpYX56dpZZYDwzPm");

                smtpClient.Send(message);
            }
        }
    }
}
