using Nhom2.TMDT.Data.Entities;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Commands.UpdateShipmentDetail
{
    public interface IUpdateShipmentDetailCommand
    {
        Task<bool> ExecutedAsync(ShipmentDetail shipmentDetail);
    }
}