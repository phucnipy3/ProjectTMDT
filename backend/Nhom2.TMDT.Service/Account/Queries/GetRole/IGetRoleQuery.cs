using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.GetRole
{
    public interface IGetRoleQuery
    {
        Task<int> ExecutedAsync(string userName);
    }
}