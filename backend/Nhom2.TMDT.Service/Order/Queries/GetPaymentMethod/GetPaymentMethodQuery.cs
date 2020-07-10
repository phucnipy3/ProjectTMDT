using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.Extensions;
using System;
using System.Collections.Generic;

namespace Nhom2.TMDT.Service.Order.Queries.GetPaymentMethod
{
    public class GetPaymentMethodQuery : IGetPaymentMethodQuery
    {
        public List<string> Executed()
        {
            List<string> data = new List<string>();

            foreach (PaymentMethod paymentMethod in Enum.GetValues(typeof(PaymentMethod)))
                data.Add(paymentMethod.GetDescription());

            return data;
        }
    }
}
