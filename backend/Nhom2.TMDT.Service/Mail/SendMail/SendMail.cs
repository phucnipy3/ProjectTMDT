using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Mail.SendMail
{
    public class SendMail : ISendMail
    {
        public async Task<bool> ExecutedAsync(string email, string subject, string body)
        {
            try
            {
                var mail = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("phucnipy3@gmail.com", "PhucNipy1999xyz"),
                    EnableSsl = true
                };

                var masage = new MailMessage();
                masage.From = new MailAddress("phucnipy3@gmail.com");
                masage.ReplyToList.Add("phucnipy3@gmail.com");
                masage.To.Add(new MailAddress(email));
                masage.Subject = subject;
                masage.Body = body;
                masage.IsBodyHtml = true;
                await mail.SendMailAsync(masage);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
