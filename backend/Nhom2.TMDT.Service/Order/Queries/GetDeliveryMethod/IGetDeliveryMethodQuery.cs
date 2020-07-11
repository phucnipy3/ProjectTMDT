using Nhom2.TMDT.Service.Order.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.GetDeliveryMethod
{
    public interface IGetDeliveryMethodQuery
    {
        List<DeliveryMethodViewModel> Executed();
    }
}