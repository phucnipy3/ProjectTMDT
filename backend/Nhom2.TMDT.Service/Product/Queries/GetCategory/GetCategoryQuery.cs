using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Product.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetCategory
{
    public class GetCategoryQuery : IGetCategoryQuery
    {
        private readonly ApplicationContext db;

        public GetCategoryQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<List<CategoryViewModel>> ExecutedAsync()
        {
            var data = await db.Categories.Where(x => x.Status == true).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            data.Add(new CategoryViewModel() { Id = -3, Name = "Đang hot" });
            data.Add(new CategoryViewModel() { Id = -2, Name = "Mới nhất" });
            data.Add(new CategoryViewModel() { Id = -1, Name = "Bán chạy" });

            return data;
        }
    }
}
