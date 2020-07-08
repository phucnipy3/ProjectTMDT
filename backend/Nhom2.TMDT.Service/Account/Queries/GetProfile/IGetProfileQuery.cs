using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.GetProfile
{
    public interface IGetProfileQuery
    {
        Task<ProfileViewModel> ExecutedAsync(string userName);
    }
}