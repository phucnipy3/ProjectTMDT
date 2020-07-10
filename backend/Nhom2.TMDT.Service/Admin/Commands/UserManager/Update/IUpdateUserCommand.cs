using Nhom2.TMDT.Data.Entities;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.UserManager.Update
{
    public interface IUpdateUserCommand
    {
        Task<bool> ExecutedAsync(User user);
    }
}