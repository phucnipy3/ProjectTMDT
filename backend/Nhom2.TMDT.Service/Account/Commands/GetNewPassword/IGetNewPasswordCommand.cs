using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.GetNewPassword
{
    public interface IGetNewPasswordCommand
    {
        Task<bool> ExecutedAsync(NewPasswordViewModel newPasswordViewModel);
    }
}