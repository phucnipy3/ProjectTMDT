using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Commands.DeleteShipmentDetail
{
    public class DeleteShipmentDetailCommand : IDeleteShipmentDetailCommand
    {
        private readonly ApplicationContext db;

        public DeleteShipmentDetailCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId, int shipmentDetailId)
        {
            try
            {
                var shipmentDetail = await db.ShipmentDetails.Where(x => x.UserId == userId && x.Id == shipmentDetailId).FirstOrDefaultAsync();

                if (shipmentDetail == null)
                    return false;

                shipmentDetail.UserId = null;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
