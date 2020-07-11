using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Commands.DeleteShipmentDetail
{
    public interface IDeleteShipmentDetailCommand
    {
        Task<bool> ExecutedAsync(int userId, int shipmentDetailId);
    }
}