using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.Register
{
    public interface IRegisterQuery
    {
        Task<bool> ExecutedAsync(RegisterViewModel registerViewModel);
    }
}