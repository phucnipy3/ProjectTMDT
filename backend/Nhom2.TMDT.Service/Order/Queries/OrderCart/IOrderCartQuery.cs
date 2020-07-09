using Nhom2.TMDT.Service.Admin.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.OrderCart
{
    public interface IOrderCartQuery
    {
        Task<bool> ExecutedAsync(string userName, OrderCartViewModel orderCartViewModel);
    }
}