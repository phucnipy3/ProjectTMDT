using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.ConfirmOrder
{
    public interface IConfirmOrderQuery
    {
        Task<bool> ExecutedAsync(int orderId, bool isCancel);
    }
}