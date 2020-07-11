using System.ComponentModel;

namespace Nhom2.TMDT.Common.Enums
{
    public enum PaymentMethod
    {
        [Description("Thanh toán khi nhận hàng")]
        Cash = 1,
        [Description("Thanh toán bẳng thẻ tín dụng/ ghi nợ")]
        Credit = 2,
        [Description("Thanh toán bằng ví điện tử (ZaloPay, Momo...)")]
        ElectronicWallet = 3,
        [Description("Thanh toán bằng PayPal")]
        PayPal = 4
    }
}
