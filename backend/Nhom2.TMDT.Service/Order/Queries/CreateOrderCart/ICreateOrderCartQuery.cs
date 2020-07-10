using Nhom2.TMDT.Service.Order.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.CreateOrderCart
{
    public interface ICreateOrderCartQuery
    {
        Task<bool> ExecutedAsync(int userId, OrderCartViewModel orderCartViewModel);
    }
}