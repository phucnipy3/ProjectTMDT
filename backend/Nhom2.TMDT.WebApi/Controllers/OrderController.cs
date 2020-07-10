using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Service.Order.Queries.CreateOrderCart;
using Nhom2.TMDT.Service.Order.Queries.GetDeliveryMethod;
using Nhom2.TMDT.Service.Order.Queries.GetOrder;
using Nhom2.TMDT.Service.Order.Queries.GetOrderDetail;
using Nhom2.TMDT.Service.Order.Queries.GetPaymentMethod;
using Nhom2.TMDT.Service.Order.ViewModels;
using Nhom2.TMDT.Service.Order.Queries.GetShipmentDetail;
using System.Security.Claims;
using System.Threading.Tasks;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Service.Order.Commands.UpdateShipmentDetail;
using Nhom2.TMDT.Service.Order.Queries.GetOrderStatus;
using Nhom2.TMDT.Service.Order.Commands.CancelOrder;
using Nhom2.TMDT.Service.Order.Commands.DeleteShipmentDetail;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IGetOrderQuery getOrderQuery;
        private readonly IGetOrderDetailQuery getOrderDetailQuery;
        private readonly IGetDeliveryMethodQuery getDeliveryMethodQuery;
        private readonly IGetPaymentMethodQuery getPaymentMethodQuery;
        private readonly ICreateOrderCartQuery createOrderCartQuery;
        private readonly IGetShipmentDetailQuery getShipmentDetailQuery;
        private readonly IUpdateShipmentDetailCommand updateShipmentDetailCommand;
        private readonly IGetOrderStatusQuery getOrderStatusQuery;
        private readonly ICancelOrderCommand cancelOrderCommand;
        private readonly IDeleteShipmentDetailCommand deleteShipmentDetailCommand;

        public OrderController(IGetOrderQuery getOrderQuery, IGetOrderDetailQuery getOrderDetailQuery, IGetDeliveryMethodQuery getDeliveryMethodQuery, IGetPaymentMethodQuery getPaymentMethodQuery, ICreateOrderCartQuery createOrderCartQuery, IGetShipmentDetailQuery getShipmentDetailQuery, IUpdateShipmentDetailCommand updateShipmentDetailCommand, IGetOrderStatusQuery getOrderStatusQuery, ICancelOrderCommand cancelOrderCommand, IDeleteShipmentDetailCommand deleteShipmentDetailCommand)
        {
            this.getOrderQuery = getOrderQuery;
            this.getOrderDetailQuery = getOrderDetailQuery;
            this.getDeliveryMethodQuery = getDeliveryMethodQuery;
            this.getPaymentMethodQuery = getPaymentMethodQuery;
            this.createOrderCartQuery = createOrderCartQuery;
            this.getShipmentDetailQuery = getShipmentDetailQuery;
            this.updateShipmentDetailCommand = updateShipmentDetailCommand;
            this.getOrderStatusQuery = getOrderStatusQuery;
            this.cancelOrderCommand = cancelOrderCommand;
            this.deleteShipmentDetailCommand = deleteShipmentDetailCommand;
        }

        [HttpGet("GetOrders")]
        [Authorize]
        public async Task<IActionResult> GetOrderAsync(string searchString, int status = 0, int pageNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getOrderQuery.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), searchString, status, pageNumber, pageSize));
        }

        [HttpGet("GetOrderDetail")]
        [Authorize]
        public async Task<IActionResult> GetOrderDetailAsync(int orderId)
        {
            return new ObjectResult(await getOrderDetailQuery.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), orderId));
        }

        [HttpGet("GetDeliveryMethod")]
        [AllowAnonymous]
        public IActionResult GetDeliveryMethod()
        {
            return new ObjectResult(getDeliveryMethodQuery.Executed());
        }

        [HttpGet("GetPaymentMethod")]
        [AllowAnonymous]
        public IActionResult GetPaymentMethod()
        {
            return new ObjectResult(getPaymentMethodQuery.Executed());
        }

        [HttpPost("CreateOrderCart")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrderCartAsync([FromBody]OrderCartViewModel orderCartViewModel)
        {
            int userId;
            int.TryParse(User.FindFirstValue(ClaimTypes.Sid), out userId);
            return new ObjectResult(await createOrderCartQuery.ExecutedAsync(userId, orderCartViewModel));
        }

        [HttpGet("GetShipmentDetails")]
        [Authorize]
        public async Task<IActionResult> GetShipmentDetailAsync()
        {
            return new ObjectResult(await getShipmentDetailQuery.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid))));
        }

        [HttpGet("GetOrderStatus")]
        [Authorize]
        public IActionResult GetOrderStatusAsync()
        {
            return new ObjectResult(getOrderStatusQuery.Executed());
        }

        [HttpPost("UpdateShipmentDetail")]
        [Authorize]
        public async Task<IActionResult> UpdateShipmentDetailAsync([FromBody]ShipmentDetail shipmentDetail)
        {
            return new ObjectResult(await updateShipmentDetailCommand.ExecutedAsync(shipmentDetail));
        }

        [HttpGet("CancelOrder")]
        [Authorize]6
        public async Task<IActionResult> CancelOrderAsync(int orderId)
        {
            return new ObjectResult(await cancelOrderCommand.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), orderId));
        }

        [HttpGet("DeleteShipmentDetail")]
        [Authorize]
        public async Task<IActionResult> DeleteShipmentDetailAsync(int shipmentDetailId)
        {
            return new ObjectResult(await deleteShipmentDetailCommand.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), shipmentDetailId));
        }
    }
}
