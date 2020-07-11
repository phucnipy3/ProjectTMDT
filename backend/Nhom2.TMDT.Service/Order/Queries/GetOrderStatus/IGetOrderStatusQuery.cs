using Nhom2.TMDT.Service.Order.ViewModels;
using System.Collections.Generic;

namespace Nhom2.TMDT.Service.Order.Queries.GetOrderStatus
{
    public interface IGetOrderStatusQuery
    {
        List<OrderStatusViewModel> Executed();
    }
}