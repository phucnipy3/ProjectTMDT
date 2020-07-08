using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Service.Order.Queries.GetOrder;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly GetOrderQuery getOrderQuery;

        public OrderController(GetOrderQuery getOrderQuery)
        {
            this.getOrderQuery = getOrderQuery;
        }

        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrderAsync(string searchString, int pageNumber, int pageSize)
        {
            return new ObjectResult(await getOrderQuery.ExecutedAsync(User.Identity.Name , searchString, pageNumber, pageSize));
        }
    }
}
