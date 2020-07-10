using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.UserManager.Delete
{
    public interface IDeleteUserQuery
    {
        Task<bool> ExecutedAsync(int userId);
    }
}