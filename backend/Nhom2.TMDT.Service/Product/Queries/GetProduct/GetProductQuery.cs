using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Product.ViewModels;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetProduct
{
    public class GetProductQuery : IGetProductQuery
    {
        private readonly ApplicationContext db;

        public GetProductQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<PagedList<ProductCardViewModel>> ExecutedAsync(int category, string searchString, int pageNumber, int pageSize)
        {
            var table = db.Products.Where(x => x.Status == true).AsQueryable();

            switch (category)
            {
                case -3: //Hot
                    table = table.OrderBy(x => x.PromotionPrice / x.Price);
                    break;
                case -2: //New
                    table = table.OrderByDescending(x => x.CreatedDate);
                    break;
                case -1: //BestSaler
                    table = table.OrderByDescending(x => x.OrderDetails.Where(y => y.ProductId == x.Id && y.Order.Status == 4).Sum(y => y.Count));
                    break;
                case 0:  //Nomal 
                    break;
                default: //Category
                    table = table.Where(x => x.Category.Id == category);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                string[] searchStrings = Regex.Split(searchString.Trim(), @"\s+|@|&|'|\(|\)|<|>|#|\+|-|\*|/").Where(s => !String.IsNullOrEmpty(s)).ToArray();
                //no split
                table = table.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }

            PagedList<ProductCardViewModel> data = new PagedList<ProductCardViewModel>();

            data.Items = await table.Select(x => new ProductCardViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Price = x.Price.GetValueOrDefault(),
                PromotionPrice = x.PromotionPrice
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            data.PageNumber = pageNumber;
            data.PageSize = pageSize;
            data.TotalCount = await table.CountAsync();

            return data;
        }
    }
}
