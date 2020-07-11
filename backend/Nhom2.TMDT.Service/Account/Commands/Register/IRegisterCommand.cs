using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.Register
{
    public interface IRegisterCommand
    {
        Task<bool> ExecutedAsync(RegisterViewModel registerViewModel);
    }
}