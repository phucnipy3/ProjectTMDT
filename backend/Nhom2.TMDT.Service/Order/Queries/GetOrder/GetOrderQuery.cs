using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Admin.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.GetOrder
{
    public class GetOrderQuery : IGetOrderQuery
    {
        private readonly ApplicationContext db;

        public GetOrderQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<PagedList<OrderViewModel>> ExecutedAsync(string userName, string searchString, int pageNumber, int pageSize)
        {
            var table = db.Orders.Where(x => x.Status != -1).AsQueryable();
            var user = await db.Users.SingleOrDefaultAsync(x => x.Username.Equals(userName));

            if (user != null && user.Role.GetValueOrDefault() == (int)Role.Customer)
            {
                table = table.Where(x => x.CreatedBy == user.Id);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                table = table.Where(x => x.User.Name.Contains(searchString) || x.OrderDetails.Any(x => x.Product.Name.Contains(searchString)));
            }

            PagedList<OrderViewModel> data = new PagedList<OrderViewModel>();

            data.Items = await table.OrderByDescending(x => x.CreatedDate).Select(x => new OrderViewModel()
            {
                Id = x.Id,
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
            }).Skip((pageSize - 1) * pageNumber).Take(pageNumber).ToListAsync();

            data.PageNumber = pageNumber;
            data.PageSize = pageSize;
            data.TotalCount = await table.CountAsync();

            return data;
        }
    }
}
