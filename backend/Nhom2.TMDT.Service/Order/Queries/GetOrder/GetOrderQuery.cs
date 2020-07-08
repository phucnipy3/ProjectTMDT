using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Order.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.GetOrder
{
    public class GetOrderQuery : IGetOrderQuery
    {
        private readonly ApplicationContext db;

        public GetOrderQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<PagedList<OrderViewModel>> ExecutedAsync(string userName, string searchString, int pageNumber = 1, int pageSize = 10)
        {
            var table = db.Orders.AsQueryable();

            if (userName.Equals(Role.Customer.ToString()))
            {

            }
            else
            {

            }

            if (!string.IsNullOrEmpty(searchString))
            {

            }

            PagedList<OrderViewModel> data = new PagedList<OrderViewModel>();

            data.Items = await table.Select(x => new OrderViewModel()
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
