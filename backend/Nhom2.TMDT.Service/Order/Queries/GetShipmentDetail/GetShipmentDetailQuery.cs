using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.GetShipmentDetail
{
    public class GetShipmentDetailQuery : IGetShipmentDetailQuery
    {
        private readonly ApplicationContext db;

        public GetShipmentDetailQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<List<ShipmentDetail>> ExecutedAsync(int userId)
        {
            var data = await db.Users.Where(x => x.Id == userId).Select(x => x.ShipmentDetail).ToListAsync();

            return data;
        }
    }
}
