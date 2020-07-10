using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Admin.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.OrderCart
{
    public class OrderCartQuery : IOrderCartQuery
    {
        private readonly ApplicationContext db;

        public OrderCartQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(string userName, OrderCartViewModel orderCartViewModel)
        {
            Data.Entities.Order order = new Data.Entities.Order();

            if (!await db.ShipmentDetails.AnyAsync(x => x.Id == orderCartViewModel.ShipmentDetail.Id))
            {
                await db.ShipmentDetails.AddAsync(orderCartViewModel.ShipmentDetail);
            }

            foreach (CartItemViewModel item in orderCartViewModel.CartItems)
            {
                if (await db.Products.Where(x => x.Id == item.Id).AnyAsync(x => x.Quantity.GetValueOrDefault() < orderCartViewModel.CartItems.Count))
                    return false;

                await db.OrderDetails.AddAsync(new OrderDetail()
                {
                    ProductId = item.Id,
                    Count = item.Count,
                    Price = item.Price,
                    PromotionPrice = item.PromotionPrice
                });
            }

            order.DeliveryMethod = orderCartViewModel.DeliveryMethod.Name;
            order.TotalShipping = orderCartViewModel.DeliveryMethod.Cost;
            order.PaymentMethod = orderCartViewModel.PaymentMethod;
            order.ShipmentDetailId = orderCartViewModel.ShipmentDetail.Id;
            order.Ordered = DateTime.Now;
            order.Status = 1;

            var user = await db.Users.Where(x => x.Username == userName).SingleOrDefaultAsync();
            order.CreatedBy = user.Id;

            await db.Orders.AddAsync(order);

            await db.SaveChangesAsync();
            return true;
        }
    }
}
