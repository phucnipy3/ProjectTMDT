using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Mail.SendMail;
using Nhom2.TMDT.Service.Order.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.CreateOrderCart
{
    public class CreateOrderCartQuery : ICreateOrderCartQuery
    {
        private readonly ApplicationContext db;
        private ISendMail sendMail;

        public CreateOrderCartQuery(ApplicationContext db, ISendMail sendMail)
        {
            this.db = db;
            this.sendMail = sendMail;
        }

        public async Task<bool> ExecutedAsync(int userId, OrderCartViewModel orderCartViewModel)
        {
            try
            {
                Data.Entities.Order order = new Data.Entities.Order();

                if (userId != 0)
                {
                    order.CreatedBy = userId;
                    orderCartViewModel.ShipmentDetail.UserId = userId;
                }
                    
                if (await db.ShipmentDetails.AnyAsync(x => x.Id == orderCartViewModel.ShipmentDetail.Id))
                {
                    order.ShipmentDetailId = orderCartViewModel.ShipmentDetail.Id;
                }
                else
                {
                    order.ShipmentDetail = orderCartViewModel.ShipmentDetail;
                }

                foreach (CartItemViewModel item in orderCartViewModel.CartItems)
                {
                    if (await db.Products.Where(x => x.Id == item.Id).AnyAsync(x => x.Quantity.GetValueOrDefault() < orderCartViewModel.CartItems.Count))
                        return false;

                    order.OrderDetails.Add(new OrderDetail()
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
                order.Ordered = DateTime.Now;
                order.Status = 1;

                db.Orders.Add(order);

                string body = File.ReadAllText("./Templates/MailOrderInformationTemplate.html");

                var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userId);

                body = body.Replace("@Name", user == null ? "" : user.Name);
                body = body.Replace("@Status", "được đặt");
                body = body.Replace("@Time", DateTime.Now.ToString());

                await sendMail.ExecutedAsync(order.User.ShipmentDetails.First().Email, "Order information", body);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
