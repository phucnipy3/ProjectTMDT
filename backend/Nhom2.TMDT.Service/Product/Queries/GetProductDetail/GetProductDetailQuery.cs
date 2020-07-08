using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Product.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IGetProductDetailQuery
    {
        private readonly ApplicationContext db;

        public GetProductDetailQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<ProductViewModel> ExecutedAsync(int productId)
        {
            var data = await db.Products.Where(x => x.Id == productId).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Price = x.Price.GetValueOrDefault(),
                PromotionPrice = x.PromotionPrice,
                Detail = x.Detail,
                Name = x.Name,
                Brand = x.Brand
            }).SingleOrDefaultAsync();

            return data;
        }
    }
}
