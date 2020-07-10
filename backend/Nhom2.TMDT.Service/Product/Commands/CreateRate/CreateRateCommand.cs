using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Commands.CreateRate
{
    public class CreateRateCommand : ICreateRateCommand
    {
        private readonly ApplicationContext db;

        public CreateRateCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId, int productId, int point)
        {
            try
            {
                var rate = await db.Rates.Where(x => x.CreatedBy == userId && x.ProductId == productId).FirstOrDefaultAsync();

                if (rate == null)
                {
                    await db.Rates.AddAsync(new Data.Entities.Rate()
                    {
                        ProductId = productId,
                        RatePoint = point,
                        CreatedBy = userId
                    });
                }
                else
                {
                    rate.RatePoint = point;
                }

                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
    }
}
