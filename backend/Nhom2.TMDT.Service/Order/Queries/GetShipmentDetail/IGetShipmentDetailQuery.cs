using Nhom2.TMDT.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.GetShipmentDetail
{
    public interface IGetShipmentDetailQuery
    {
        Task<List<ShipmentDetail>> ExecutedAsync(int userId);
    }
}