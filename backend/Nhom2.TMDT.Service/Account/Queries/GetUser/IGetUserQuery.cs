using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.GetUser
{
    public interface IGetUserQuery
    {
        Task<UserViewModel> ExecutedAsync(string userName);
    }
}