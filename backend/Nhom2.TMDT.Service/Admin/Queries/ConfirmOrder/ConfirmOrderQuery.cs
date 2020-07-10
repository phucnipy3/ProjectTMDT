using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Mail.SendMail;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.ConfirmOrder
{
    public class ConfirmOrderQuery : IConfirmOrderQuery
    {
        private readonly ApplicationContext db;
        private ISendMail sendMail;

        public ConfirmOrderQuery(ApplicationContext db, ISendMail sendMail)
        {
            this.db = db;
            this.sendMail = sendMail;
        }

        public async Task<bool> ExecutedAsync(int orderId, bool isCancel)
        {
            try
            {
                var order = await db.Orders.Include(x => x.ShipmentDetail).Where(x => x.Id == orderId).FirstOrDefaultAsync();
                if (order != null)
                {
                    string body = File.ReadAllText("./Templates/MailOrderInformationTemplate.html");

                    body = body.Replace("@Name", order.User.Name);

                    if (isCancel)
                    {
                        order.Status = 5;
                        order.Canceled = DateTime.Now;

                        body = body.Replace("@Status", "bị hủy");
                        body = body.Replace("@Time", DateTime.Now.ToString());
                    }
                    else
                    {
                        switch (order.Status)
                        {
                            case 0:
                                order.Ordered = DateTime.Now;
                                order.Status++;
                                body = body.Replace("@Status", "được đặt");
                                body = body.Replace("@Time", DateTime.Now.ToString());
                                break;
                            case 1:
                                order.Confirmed = DateTime.Now;
                                order.Status++;
                                body = body.Replace("@Status", "được xác nhận");
                                body = body.Replace("@Time", DateTime.Now.ToString());
                                break;
                            case 2:
                                order.Transporting = DateTime.Now;
                                order.Status++;
                                body = body.Replace("@Status", "chuyển sang trạng thái lấy hàng");
                                body = body.Replace("@Time", DateTime.Now.ToString());
                                break;
                            case 3:
                                order.Completed = DateTime.Now;
                                order.Status++;
                                body = body.Replace("@Status", "hoàn thành");
                                body = body.Replace("@Time", DateTime.Now.ToString());
                                break;
                        }

                        await sendMail.ExecutedAsync(order.ShipmentDetail.Email, "Order information", body);
                        await db.SaveChangesAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
