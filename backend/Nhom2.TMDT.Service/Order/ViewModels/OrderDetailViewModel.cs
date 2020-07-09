using Nhom2.TMDT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nhom2.TMDT.Service.Admin.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ShipmentDetail ShipmentDetail { get; set; }
        public List<CartItemViewModel> Products { get; set; }
        public List<TimeLog> TimeLogs { get; set; }
        public decimal TotalProductMoney
        {
            get
            {
                return Products.Sum(x => (x.PromotionPrice ?? x.Price) * x.Count);
            }
        }
        public string DeliveryMothod { get; set; }
        public decimal TotalShipping { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalMoney
        {
            get
            {
                return TotalProductMoney + TotalShipping;
            }
        }
        public DateTime CreatedDate { get; set; }
    }

    public class TimeLog
    {
        public DateTime TimeLine { get; set; }
        public string Event { get; set; }
    }
}
