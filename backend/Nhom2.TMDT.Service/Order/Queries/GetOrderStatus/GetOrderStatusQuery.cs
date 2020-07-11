using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.Extensions;
using Nhom2.TMDT.Service.Order.ViewModels;
using System;
using System.Collections.Generic;

namespace Nhom2.TMDT.Service.Order.Queries.GetOrderStatus
{
    public class GetOrderStatusQuery : IGetOrderStatusQuery
    {
        public List<OrderStatusViewModel> Executed()
        {
            List<OrderStatusViewModel> data = new List<OrderStatusViewModel>();

            data.Add(new OrderStatusViewModel() { Id = 0, Description = "Tất cả" });

            foreach (OrderStatus orderStatus in Enum.GetValues(typeof(OrderStatus)))
                if (orderStatus > 0)
                    data.Add(new OrderStatusViewModel() { Id = (int)orderStatus, Description = orderStatus.GetDescription() });

            return data;
        }
    }
}
