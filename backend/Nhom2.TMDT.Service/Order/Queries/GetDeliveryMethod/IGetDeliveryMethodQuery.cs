using Nhom2.TMDT.Service.Admin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.GetDeliveryMethod
{
    public interface IGetDeliveryMethodQuery
    {
        List<DeliveryMethodViewModel> Executed();
    }
}