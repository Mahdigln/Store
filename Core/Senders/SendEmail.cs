using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Senders
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("tt9407312@gmail.com", "Sungla");//اینجا باید ایمیلمون رو بنویسیم
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            // SmtpServer.UseDefaultCredentials = false;  //stack over flow
            SmtpServer.Credentials = new System.Net.NetworkCredential("tt9407312@gmail.com", "yoeaykiaezhcvpfd");//اینجا باید ایمیل و پسوردش رو بنویسیم
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}
