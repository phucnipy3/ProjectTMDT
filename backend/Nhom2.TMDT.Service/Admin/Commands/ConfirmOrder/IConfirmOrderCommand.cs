using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.ConfirmOrder
{
    public interface IConfirmOrderCommand
    {
        Task<bool> ExecutedAsync(int orderId, bool isCancel);
    }
}