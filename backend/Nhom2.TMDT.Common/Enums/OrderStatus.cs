using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Nhom2.TMDT.Common.Enums
{
    public enum OrderStatus
    {
        Deleted = -1,
        [Description("Chưa đặt đơn hàng")]
        Unset = 0,
        [Description("Đã đặt đơn hàng")]
        Ordered = 1,
        [Description("Đã xác nhận")]
        Confirmed = 2,
        [Description("Đang giao hàng")]
        Transporting = 3,
        [Description("Đã hoàn thành")]
        Completed = 4,
        [Description("Đã hủy")]
        Canceled = 5
    }
}
