using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Mail.SendMail
{
    public interface ISendMail
    {
        Task<bool> ExecutedAsync(string email, string subject, string body);
    }
}