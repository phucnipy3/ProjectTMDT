using Nhom2.TMDT.Data.Entities;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.UserManager.Add
{
    public interface IAddUserQuery
    {
        Task<bool> ExecutedAsync(User user);
    }
}