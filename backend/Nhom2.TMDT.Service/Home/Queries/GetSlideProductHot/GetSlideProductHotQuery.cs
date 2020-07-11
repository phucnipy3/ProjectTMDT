using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Home.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Home.Queries.GetSlideProduct
{
    public class GetSlideProductHotQuery : IGetSlideProductHotQuery
    {
        private readonly ApplicationContext db;

        public GetSlideProductHotQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<List<ProductSlideViewModel>> ExecutedAsync()
        {
            var data = await db.Products.Where(x => x.Status == true)
                .OrderBy(x => x.PromotionPrice / x.Price).Take(10)
                .Select(x => new ProductSlideViewModel()
                {
                    Id = x.Id,
                    Image = x.Image
                }).ToListAsync();

            return data;
        }
    }
}
