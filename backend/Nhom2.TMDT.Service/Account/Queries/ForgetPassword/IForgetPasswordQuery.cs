using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.ForgetPassword
{
    public interface IForgetPasswordQuery
    {
        Task<bool> ExecutedAsync(string email);
    }
}