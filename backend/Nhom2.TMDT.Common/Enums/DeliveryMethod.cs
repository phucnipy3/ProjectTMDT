using System.ComponentModel;

namespace Nhom2.TMDT.Common.Enums
{
    public enum DeliveryMethod
    {
        [Description("Giao hàng nhanh")]
        FastDelivery = 1,
        [Description("Giao hàng tiết kiệm")]
        DeliverySaving = 2,
        [Description("Viettel Post")]
        VietteelPost = 3
    }
}
