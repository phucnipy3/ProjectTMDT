using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Admin.ViewModels;
using Nhom2.TMDT.Service.Order.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.GetOrderManager
{
    public class GetOrderManagerQuery : IGetOrderManagerQuery
    {
        private readonly ApplicationContext db;

        public GetOrderManagerQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<PagedList<OrderManagerViewModel>> ExecutedAsync(string searchString, int pageNumber, int pageSize)
        {
            var table = db.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                table = table.Where(x => x.User.Name.Contains(searchString) || x.OrderDetails.Any(x => x.Product.Name.Contains(searchString)));
            }

            PagedList<OrderManagerViewModel> data = new PagedList<OrderManagerViewModel>();

            data.Items = await table.OrderByDescending(x => x.CreatedDate).Select(x => new OrderManagerViewModel()
            {
                Id = x.Id,
                UserName = x.User.Name,
                UserImage = x.User.Image,
                Products = x.OrderDetails.Select(y => new CartItemViewModel()
                {
                    Id = y.Id,
                    Image = y.Product.Image,
                    Name = y.Product.Name,
                    Count = y.Count.GetValueOrDefault(),
                    Price = y.Price.GetValueOrDefault(),
                    PromotionPrice = y.PromotionPrice
                }).ToList(),
                DeliveryMothod = x.DeliveryMethod,
                TotalShipping = x.TotalShipping.GetValueOrDefault()
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            data.PageNumber = pageNumber;
            data.PageSize = pageSize;
            data.TotalCount = await table.CountAsync();

            return data;
        }
    }
}
