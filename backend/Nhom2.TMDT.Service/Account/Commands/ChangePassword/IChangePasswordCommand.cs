using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.ChangePassword
{
    public interface IChangePasswordCommand
    {
        Task<bool> ExecutedAsync(int userId, ChangePasswordViewModel changePasswordViewModel);
    }
}