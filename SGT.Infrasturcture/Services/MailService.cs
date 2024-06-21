using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SGT.Application.Services;

namespace SGT.Infrasturcture.Services
{
    public class MailService : IMailService
    {
        public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMessageAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMessageAsync(string[] toes, string subject, string body, bool isBodyHtml = true)
        {

            //TODO: smtp tarafını düzelt.

            MailMessage mail = new();
            mail.IsBodyHtml= isBodyHtml;
            foreach (var to in toes)
                mail.To.Add(to);

            mail.Subject = subject;
            mail.Body = body;
            mail.From = new("info@samusiber@samsun.com","Samsun Üniversitesi Siber Güvenlik Topluluğu", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential("UserName","Password");

            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "HOSTNAME";
            await smtp.SendMailAsync(mail);
        }
    }
}
