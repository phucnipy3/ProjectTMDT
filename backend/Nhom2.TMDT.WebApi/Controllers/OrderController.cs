using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Service.Admin.Queries.GetDeliveryMethod;
using Nhom2.TMDT.Service.Admin.Queries.GetOrder;
using Nhom2.TMDT.Service.Admin.Queries.GetOrderDetail;
using Nhom2.TMDT.Service.Admin.Queries.GetOrderManager;
using Nhom2.TMDT.Service.Admin.Queries.GetPaymentMethod;
using Nhom2.TMDT.Service.Admin.Queries.OrderCart;
using Nhom2.TMDT.Service.Admin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IGetOrderQuery getOrderQuery;
        private readonly IGetOrderDetailQuery getOrderDetailQuery;
        private readonly IGetDeliveryMethodQuery getDeliveryMethodQuery;
        private readonly IGetPaymentMethodQuery getPaymentMethodQuery;
        private readonly IOrderCartQuery orderCartQuery;

        public OrderController(IGetOrderQuery getOrderQuery, IGetOrderDetailQuery getOrderDetailQuery, IGetDeliveryMethodQuery getDeliveryMethodQuery, IGetPaymentMethodQuery getPaymentMethodQuery, IOrderCartQuery orderCartQuery)
        {
            this.getOrderQuery = getOrderQuery;
            this.getOrderDetailQuery = getOrderDetailQuery;
            this.getDeliveryMethodQuery = getDeliveryMethodQuery;
            this.getPaymentMethodQuery = getPaymentMethodQuery;
            this.orderCartQuery = orderCartQuery;
        }

        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrderAsync(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getOrderQuery.ExecutedAsync(User.Identity.Name, searchString, pageNumber, pageSize));
        }

        [HttpGet("GetOrderDetail")]
        public async Task<IActionResult> GetOrderDetailAsync(int orderId)
        {
            return new ObjectResult(await getOrderDetailQuery.ExecutedAsync(orderId));
        }

        [HttpGet("GetDeliveryMethod")]
        public IActionResult GetDeliveryMethod()
        {
            return new ObjectResult(getDeliveryMethodQuery.Executed());
        }

        [HttpGet("GetPaymentMethod")]
        public IActionResult GetPaymentMethod()
        {
            return new ObjectResult(getPaymentMethodQuery.Executed());
        }

        [HttpPost("OrderCart")]
        public async Task<IActionResult> OrderCartAsync(OrderCartViewModel orderCartViewModel)
        {
            return new ObjectResult(await orderCartQuery.ExecutedAsync(User.Identity.Name, orderCartViewModel));
        }
    }
}
