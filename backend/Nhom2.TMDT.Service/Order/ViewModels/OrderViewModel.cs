using System.Collections.Generic;
using System.Linq;

namespace Nhom2.TMDT.Service.Order.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public List<CartItemViewModel> Products { get; set; }
        public string DeliveryMothod { get; set; }
        public decimal TotalShipping { get; set; }
        public decimal TotalProductMoney
        {
            get
            {
                return Products.Sum(x => (x.PromotionPrice ?? x.Price) * x.Count) + TotalShipping;
            }
        }
    }
}
