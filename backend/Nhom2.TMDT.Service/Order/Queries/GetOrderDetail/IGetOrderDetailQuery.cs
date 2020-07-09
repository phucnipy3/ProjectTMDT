using Nhom2.TMDT.Service.Admin.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.GetOrderDetail
{
    public interface IGetOrderDetailQuery
    {
        Task<OrderDetailViewModel> ExecutedAsync(int orderId);
    }
}