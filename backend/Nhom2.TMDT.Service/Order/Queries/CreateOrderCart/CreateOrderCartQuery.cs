using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Order.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.CreateOrderCart
{
    public class CreateOrderCartQuery : ICreateOrderCartQuery
    {
        private readonly ApplicationContext db;

        public CreateOrderCartQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId, OrderCartViewModel orderCartViewModel)
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

            if (userId != 0)
                order.CreatedBy = userId;

            await db.Orders.AddAsync(order);

            await db.SaveChangesAsync();
            return true;
        }
    }
}
