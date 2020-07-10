using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.Extensions;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Order.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IGetOrderDetailQuery
    {
        private readonly ApplicationContext db;

        public GetOrderDetailQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<OrderDetailViewModel> ExecutedAsync(int userId, int orderId)
        {
            var table = db.Orders.Where(x => x.Id == orderId && x.CreatedBy == userId);
            var data = await table.Select(x => new OrderDetailViewModel()
            {
                Id = x.Id,
                ShipmentDetail = new Data.Entities.ShipmentDetail() 
                {
                    Id = x.ShipmentDetail.Id,
                    Name = x.ShipmentDetail.Name,
                    Address = x.ShipmentDetail.Address,
                    Email = x.ShipmentDetail.Email,
                    PhoneNumber = x.ShipmentDetail.PhoneNumber
                },
                Products = x.OrderDetails.Select(y => new CartItemViewModel()
                {
                    Id = y.Id,
                    Image = y.Product.Image,
                    Name = y.Product.Name,
                    Count = y.Count.GetValueOrDefault(),
                    Price = y.Price.GetValueOrDefault(),
                    PromotionPrice = y.PromotionPrice
                }).ToList(),
                StatusCode = x.Status.GetValueOrDefault(),
                DeliveryMothod = x.DeliveryMethod,
                TotalShipping = x.TotalShipping.GetValueOrDefault(),
                PaymentMethod = x.PaymentMethod
            }).FirstOrDefaultAsync();

            var order = await table.FirstOrDefaultAsync();

            var timeLogs = new List<TimeLog>();
            if (order.Ordered.HasValue)
                timeLogs.Add(new TimeLog() { TimeLine = order.Ordered.GetValueOrDefault(), Event = OrderStatus.Ordered.GetDescription() });
            if (order.Confirmed.HasValue)
                timeLogs.Add(new TimeLog() { TimeLine = order.Confirmed.GetValueOrDefault(), Event = OrderStatus.Confirmed.GetDescription() });
            if (order.Transporting.HasValue)
                timeLogs.Add(new TimeLog() { TimeLine = order.Transporting.GetValueOrDefault(), Event = OrderStatus.Transporting.GetDescription() });
            if (order.Completed.HasValue)
                timeLogs.Add(new TimeLog() { TimeLine = order.Completed.GetValueOrDefault(), Event = OrderStatus.Completed.GetDescription() });
            if (order.Canceled.HasValue)
                timeLogs.Add(new TimeLog() { TimeLine = order.Canceled.GetValueOrDefault(), Event = OrderStatus.Canceled.GetDescription() });

            data.TimeLogs = timeLogs.OrderByDescending(x => x.TimeLine).ToList();

            return data;
        }
    }
}
