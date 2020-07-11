using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.UserManager.Delete
{
    public interface IDeleteUserCommand
    {
        Task<bool> ExecutedAsync(int userId);
    }
}