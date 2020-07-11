using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.ActiveAccount
{
    public interface IActiveAccountCommand
    {
        Task<bool> ExecutedAsync(ActiveViewModel activeViewModel);
    }
}