using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.UpdateProfile
{
    public interface IUpdateProfileCommand
    {
        Task<bool> ExecutedAsync(int userId, ProfileViewModel profileViewModel);
    }
}