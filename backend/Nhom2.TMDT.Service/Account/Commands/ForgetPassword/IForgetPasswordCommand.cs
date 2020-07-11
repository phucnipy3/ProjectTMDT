using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.ForgetPassword
{
    public interface IForgetPasswordCommand
    {
        Task<bool> ExecutedAsync(string email);
    }
}