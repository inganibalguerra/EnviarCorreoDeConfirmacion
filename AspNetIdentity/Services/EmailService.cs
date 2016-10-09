using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
//cOMENT//Ario nuevo
namespace AspNetIdentity.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            //await configSendGridasync(message);
            await configSendSmtp(message);
        }
        private async Task configSendSmtp(IdentityMessage message)
        {
            using (System.Net.Mail.MailMessage MailSetup = new System.Net.Mail.MailMessage())
            {
                NetworkCredential loginInfo = new NetworkCredential("aqui tu correo", "aqui tu contraseña");
                MailSetup.Subject = message.Subject;
                MailSetup.To.Add(message.Destination);
                MailSetup.From = new System.Net.Mail.MailAddress("tramites@valledupar.gov.co", "Avanzar es Posible!!!");
                MailSetup.Body = message.Body;
                using (System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient("smtp.live.com"))
                {
                    SMTP.Port = 587;
                    SMTP.EnableSsl = true;
                    SMTP.Credentials = loginInfo;
                    await SMTP.SendMailAsync(MailSetup);
                }
            }


        }
        
    }
}