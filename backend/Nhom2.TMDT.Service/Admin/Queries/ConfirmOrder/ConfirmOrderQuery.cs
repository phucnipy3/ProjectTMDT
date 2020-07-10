using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.ConfirmOrder
{
    public class ConfirmOrderQuery : IConfirmOrderQuery
    {
        private readonly ApplicationContext db;

        public ConfirmOrderQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int orderId, bool isCancel)
        {
            try
            {
                var order = await db.Orders.Where(x => x.Id == orderId).FirstOrDefaultAsync();
                if (order != null)
                {
                    if (isCancel)
                    {
                        order.Status = 5;
                        order.Canceled = DateTime.Now;
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        switch (order.Status)
                        {
                            case 0:
                                order.Ordered = DateTime.Now;
                                order.Status++;
                                break;
                            case 1:
                                order.Confirmed = DateTime.Now;
                                order.Status++;
                                break;
                            case 2:
                                order.Transporting = DateTime.Now;
                                order.Status++;
                                break;
                            case 3:
                                order.Completed = DateTime.Now;
                                order.Status++;
                                break;
                        }
                        await db.SaveChangesAsync();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
