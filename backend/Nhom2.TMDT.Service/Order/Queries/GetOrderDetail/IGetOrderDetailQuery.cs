using Nhom2.TMDT.Service.Order.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.GetOrderDetail
{
    public interface IGetOrderDetailQuery
    {
        Task<OrderDetailViewModel> ExecutedAsync(int userId, int orderId);
    }
}