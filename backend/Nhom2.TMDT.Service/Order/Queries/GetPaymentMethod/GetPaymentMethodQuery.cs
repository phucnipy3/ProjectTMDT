using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Common.Extensions;
using Nhom2.TMDT.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2.TMDT.Service.Admin.Queries.GetPaymentMethod
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
