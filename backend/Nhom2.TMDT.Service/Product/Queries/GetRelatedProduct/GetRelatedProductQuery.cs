using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Product.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetRelatedProduct
{
    public class GetRelatedProductQuery : IGetRelatedProductQuery
    {
        private readonly ApplicationContext db;

        public GetRelatedProductQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<List<ProductCardViewModel>> ExecutedAsync(int productId)
        {
            var temp = db.Products.Single(x => x.Id == productId);

            var data = await db.Products.OrderByDescending(x => x.CategoryId == temp.CategoryId).ThenByDescending(x => x.CreatedDate)
                .Select(x => new ProductCardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    Price = x.Price.GetValueOrDefault(),
                    PromotionPrice = x.PromotionPrice
                }).Take(10).ToListAsync();

            return data;
        }
    }
}
