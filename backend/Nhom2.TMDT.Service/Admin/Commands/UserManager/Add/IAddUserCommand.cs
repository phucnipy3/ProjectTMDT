using Nhom2.TMDT.Data.Entities;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.UserManager.Add
{
    public interface IAddUserCommand
    {
        Task<bool> ExecutedAsync(User user);
    }
}