using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.Rate
{
    public class RateQuery : IRateQuery
    {
        private readonly ApplicationContext db;

        public RateQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(string userName, int productId, int rate)
        {
            try
            {
                var user = await db.Users.Where(x => x.UserName == userName).SingleOrDefaultAsync();

                await db.Rates.AddAsync(new Data.Entities.Rate()
                {
                    ProductId = productId,
                    RatePoint = rate,
                    CreatedBy = user.Id
                });

                await db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return true;
            }
        }
    }
}
