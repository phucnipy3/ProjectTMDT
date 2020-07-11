using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.Extensions;
using Nhom2.TMDT.Service.Order.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Nhom2.TMDT.Service.Admin.ViewModels
{
    public class OrderManagerViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
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
                return Products.Sum(x => (x.PromotionPrice ?? x.Price) * x.Count) + TotalShipping;
            }
        }
        public bool CanCancel
        {
            get
            {
                return StatusCode != (int)OrderStatus.Canceled;
            }
        }
    }
}
