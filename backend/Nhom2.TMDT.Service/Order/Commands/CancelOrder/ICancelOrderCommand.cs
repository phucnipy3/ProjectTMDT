using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Commands.CancelOrder
{
    public interface ICancelOrderCommand
    {
        Task<bool> ExecutedAsync(int userId, int orderId);
    }
}