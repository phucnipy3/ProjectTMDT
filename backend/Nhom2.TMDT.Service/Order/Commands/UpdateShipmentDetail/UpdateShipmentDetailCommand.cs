using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Commands.UpdateShipmentDetail
{
    public class UpdateShipmentDetailCommand : IUpdateShipmentDetailCommand
    {
        private readonly ApplicationContext db;

        public UpdateShipmentDetailCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(ShipmentDetail shipmentDetail)
        {
            try
            {
                if (await db.ShipmentDetails.AnyAsync(x => x.Id == shipmentDetail.Id))
                {
                    db.Entry(shipmentDetail).State = EntityState.Modified;
                }
                else
                {
                    await db.ShipmentDetails.AddAsync(shipmentDetail);
                }

                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
