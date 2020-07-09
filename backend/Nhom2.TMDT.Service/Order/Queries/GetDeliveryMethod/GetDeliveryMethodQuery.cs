using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.Extensions;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Admin.ViewModels;
using System;
using System.Collections.Generic;

namespace Nhom2.TMDT.Service.Admin.Queries.GetDeliveryMethod
{
    public class GetDeliveryMethodQuery : IGetDeliveryMethodQuery
    {
        public List<DeliveryMethodViewModel> Executed()
        {
            List<DeliveryMethodViewModel> data = new List<DeliveryMethodViewModel>();

            foreach (DeliveryMethod deliveryMethod in Enum.GetValues(typeof(DeliveryMethod)))
                data.Add(new DeliveryMethodViewModel() { Id = (int)deliveryMethod, Name = deliveryMethod.GetDescription() });

            return data;
        }
    }
}
