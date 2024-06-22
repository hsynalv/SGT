using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SGT.Application.Abstraction.Services;

namespace SGT.Infrasturcture.Services
{
    public class MailService : IMailService
    {
        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] toes, string subject, string body, bool isBodyHtml = true)
        {

            //TODO: smtp tarafını düzelt.

            MailMessage mail = new();
            mail.IsBodyHtml= isBodyHtml;
            foreach (var to in toes)
                mail.To.Add(to);

            mail.Subject = subject;
            mail.Body = body;
            mail.From = new("info@samusiber.com","Samsun Universitesi Siber Güvenlik Toplulugu", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential("UserName","Password");

            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "HOSTNAME";
            await smtp.SendMailAsync(mail);
        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><strong><a target=\"_blank\" href=\"");
            mail.AppendLine("http://localhost:4200"); // TODO: burayı düzelt
            mail.AppendLine("/update-password/");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">Yeni şifre talebi için tıklayınız...</a></strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span><br>Saygılarımızla...<br><br><br>NG - Mini|E-Ticaret");

            await SendMailAsync(to, "Şifre Yenileme Talebi", mail.ToString());
        }
    }
}
