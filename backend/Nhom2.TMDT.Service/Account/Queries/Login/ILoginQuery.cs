using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Login.Queries
{
    public interface ILoginQuery
    {
        Task<User> ExecutedAsync(LoginViewModel loginViewModel);
    }
}