using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Service.Home.Queries.GetSlideProduct;
using Nhom2.TMDT.Service.Home.Queries.GetSlideProductNew;
using System.Threading.Tasks;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        private readonly IGetSlideProductHotQuery getSlideProductHotQuery;
        private readonly IGetSlideProductNewQuery getSlideProductNewQuery;

        public HomeController(IGetSlideProductHotQuery getSlideProductHotQuery, IGetSlideProductNewQuery getSlideProductNewQuery)
        {
            this.getSlideProductHotQuery = getSlideProductHotQuery;
            this.getSlideProductNewQuery = getSlideProductNewQuery;
        }

        [HttpGet("GetVersion")]
        public IActionResult GetVersion()
        {
            return new ObjectResult("1.0.0.0");
        }

        [HttpGet("GetSlideProductHot")]
        public async Task<IActionResult> GetSlideProductHotAsync()
        {
            return new ObjectResult(await getSlideProductHotQuery.ExecutedAsync());
        }

        [HttpGet("GetSlideProductNew")]
        public async Task<IActionResult> GetSlideProductNewAsync()
        {
            return new ObjectResult(await getSlideProductNewQuery.ExecutedAsync());
        }
    }
}