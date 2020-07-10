using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Product.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetRate
{
    public class GetRateQuery : IGetRateQuery
    {
        private readonly ApplicationContext db;

        public GetRateQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<RateViewModel> ExecutedAsync(int userId, int productId)
        {
            var table = db.Rates.Where(x => x.ProductId == productId);

            if (table.Count() == 0)
            {
                return new RateViewModel() { RatePoint = 0, PersentPoints = (new int[] { 0, 0, 0, 0, 0 }).ToList() , UserRate = 0 };
            }    

            RateViewModel data = new RateViewModel();

            await Task.Run(() => data.RatePoint = table.Average(x => x.RatePoint).GetValueOrDefault());

            int[] temp = { 1, 2, 3, 4, 5 };
            await Task.Run(() => data.PersentPoints = temp.GroupJoin(table, x => x, y => y.RatePoint, (x, y) => new { x, y }).Select(x => x.y.Count() * 100 / table.Count()).ToList());

            data.UserRate = await db.Rates.Where(x => x.ProductId == productId && x.CreatedBy == userId).Select(x => x.RatePoint.GetValueOrDefault()).FirstOrDefaultAsync();

            return data;
        }
    }
}
