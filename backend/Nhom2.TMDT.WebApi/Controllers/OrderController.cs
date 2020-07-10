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

        public OrderController(IGetOrderQuery getOrderQuery, IGetOrderDetailQuery getOrderDetailQuery, IGetDeliveryMethodQuery getDeliveryMethodQuery, IGetPaymentMethodQuery getPaymentMethodQuery, ICreateOrderCartQuery createOrderCartQuery, IGetShipmentDetailQuery getShipmentDetailQuery, IUpdateShipmentDetailCommand updateShipmentDetailCommand)
        {
            this.getOrderQuery = getOrderQuery;
            this.getOrderDetailQuery = getOrderDetailQuery;
            this.getDeliveryMethodQuery = getDeliveryMethodQuery;
            this.getPaymentMethodQuery = getPaymentMethodQuery;
            this.createOrderCartQuery = createOrderCartQuery;
            this.getShipmentDetailQuery = getShipmentDetailQuery;
            this.updateShipmentDetailCommand = updateShipmentDetailCommand;
        }

        [HttpGet("GetOrder")]
        [Authorize]
        public async Task<IActionResult> GetOrderAsync(string searchString, int status = -2, int pageNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getOrderQuery.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), searchString, status, pageNumber, pageSize));
        }

        [HttpGet("GetOrderDetail")]
        [Authorize]
        public async Task<IActionResult> GetOrderDetailAsync(int orderId)
        {
            return new ObjectResult(await getOrderDetailQuery.ExecutedAsync(orderId));
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

        [HttpGet("CreateOrderCart")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrderCartAsync([FromBody]OrderCartViewModel orderCartViewModel)
        {
            int userId;
            int.TryParse(User.FindFirstValue(ClaimTypes.Sid), out userId);
            return new ObjectResult(await createOrderCartQuery.ExecutedAsync(userId, orderCartViewModel));
        }

        [HttpPost("GetShipmentDetails")]
        [Authorize]
        public async Task<IActionResult> GetShipmentDetailAsync()
        {
            return new ObjectResult(await getShipmentDetailQuery.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid))));
        }

        [HttpPost("UpdateShipmentDetail")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateShipmentDetailAsync([FromBody]ShipmentDetail shipmentDetail)
        {
            return new ObjectResult(await updateShipmentDetailCommand.ExecutedAsync(shipmentDetail));
        }
    }
}
