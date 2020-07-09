using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Service.Admin.Queries.ConfirmOrder;
using Nhom2.TMDT.Service.Admin.Queries.GetOrderManager;
using System.Threading.Tasks;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IConfirmOrderQuery confirmOrderQuery;
        private readonly IGetOrderManagerQuery getOrderManagerQuery;

        public AdminController(IConfirmOrderQuery confirmOrderQuery, IGetOrderManagerQuery getOrderManagerQuery)
        {
            this.confirmOrderQuery = confirmOrderQuery;
            this.getOrderManagerQuery = getOrderManagerQuery;
        }

        [HttpGet("ConfirmOrder")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> ConfirmOrderAsync(int orderId, bool isCancel = false)
        {
            return new ObjectResult(await confirmOrderQuery.ExecutedAsync(orderId, isCancel));
        }

        [HttpGet("GetOrderManager")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> GetOrderManagerAsync(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getOrderManagerQuery.ExecutedAsync(searchString, pageNumber, pageSize));
        }
    }
}
