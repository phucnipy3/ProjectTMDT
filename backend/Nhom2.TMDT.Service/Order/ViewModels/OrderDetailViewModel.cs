using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.Extensions;
using Nhom2.TMDT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nhom2.TMDT.Service.Order.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public List<CartItemViewModel> Products { get; set; }
        public string DeliveryMothod { get; set; }
        public decimal TotalShipping { get; set; }
        public int StatusCode { private get; set; }
        public string Status
        {
            get
            {
                return ((OrderStatus)StatusCode).GetDescription();
            }
        }
        public decimal TotalProductMoney
        {
            get
            {
                return Products.Sum(x => (x.PromotionPrice ?? x.Price) * x.Count);
            }
        }
        public bool CanCancel
        {
            get
            {
                return StatusCode == (int)OrderStatus.Ordered;
            }
        }
        public string PaymentMethod { get; set; }
        public ShipmentDetail ShipmentDetail { get; set; }
        public List<TimeLog> TimeLogs { get; set; }
        public decimal TotalMoney
        {
            get
            {
                return TotalProductMoney + TotalShipping;
            }
        }
    }

    public class TimeLog
    {
        public DateTime TimeLine { get; set; }
        public string Event { get; set; }
    }
}
