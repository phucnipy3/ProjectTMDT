using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Data.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Commands.CancelOrder
{
    public class CancelOrderCommand : ICancelOrderCommand
    {
        private readonly ApplicationContext db;

        public CancelOrderCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId, int orderId)
        {
            try
            {
                var order = await db.Orders.Where(x => x.Id == orderId && x.CreatedBy == userId && x.Status == (int)OrderStatus.Ordered).FirstOrDefaultAsync();

                if (order == null)
                    return false;

                order.Status = (int)OrderStatus.Canceled;

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
