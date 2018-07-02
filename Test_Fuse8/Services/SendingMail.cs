using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Hosting;
using Test_Fuse8.ViewModels;

namespace Test_Fuse8.Services
{
    public class SendingMail
    {
        public static void SendEmail(EmailSettings settings)
        {
            var loginInfo = new NetworkCredential(settings.Email, settings.Password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient(settings.Host, settings.Port);

            msg.From = new MailAddress(settings.Email);
            msg.To.Add(new MailAddress(settings.Address));
            msg.Subject = settings.Subject;
            msg.Body = settings.Messange;
            msg.IsBodyHtml = true;
            msg.Attachments.Add(new Attachment(HostingEnvironment.MapPath("/Files/Report.xlsx")));

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }
    }
}
