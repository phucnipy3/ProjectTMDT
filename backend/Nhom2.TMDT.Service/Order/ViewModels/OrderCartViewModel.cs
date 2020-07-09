using Nhom2.TMDT.Data.Entities;
using System.Collections.Generic;

namespace Nhom2.TMDT.Service.Admin.ViewModels
{
    public class OrderCartViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }
        public ShipmentDetail ShipmentDetail { get; set; }
        public DeliveryMethodViewModel DeliveryMethod { get; set; }
        public string PaymentMethod { get; set; }
    }
}
