using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Service.Product.Commands.CreateComment;
using Nhom2.TMDT.Service.Product.Commands.CreateRate;
using Nhom2.TMDT.Service.Product.Queries.GetCategory;
using Nhom2.TMDT.Service.Product.Queries.GetComment;
using Nhom2.TMDT.Service.Product.Queries.GetProduct;
using Nhom2.TMDT.Service.Product.Queries.GetProductDetail;
using Nhom2.TMDT.Service.Product.Queries.GetRate;
using Nhom2.TMDT.Service.Product.Queries.GetRelatedProduct;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public readonly IGetProductQuery getProductQuery;
        public readonly IGetRelatedProductQuery getRelatedProductQuery;
        public readonly IGetProductDetailQuery getProductDetailQuery;
        public readonly IGetRateQuery getRateQuery;
        public readonly IGetCommentQuery getCommentQuery;
        public readonly IGetCategoryQuery getCategoryQuery;
        public readonly ICreateCommentCommand createCommentCommand;
        public readonly ICreateRateCommand createRateCommand;

        public ProductController(IGetProductQuery getProductQuery, IGetRelatedProductQuery getRelatedProductQuery, IGetProductDetailQuery getProductDetailQuery, IGetRateQuery getRateQuery, IGetCommentQuery getCommentQuery, IGetCategoryQuery getCategoryQuery, ICreateCommentCommand createCommentCommand, ICreateRateCommand createRateCommand)
        {
            this.getProductQuery = getProductQuery;
            this.getRelatedProductQuery = getRelatedProductQuery;
            this.getProductDetailQuery = getProductDetailQuery;
            this.getRateQuery = getRateQuery;
            this.getCommentQuery = getCommentQuery;
            this.getCategoryQuery = getCategoryQuery;
            this.createCommentCommand = createCommentCommand;
            this.createRateCommand = createRateCommand;
        }

        [HttpGet("GetProduct")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductAsync(int category, string searchString, int pageNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getProductQuery.ExecutedAsync(category, searchString, pageNumber, pageSize));
        }

        [HttpGet("GetRelatedProduct")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRelatedProductAsync(int productId)
        {
            return new ObjectResult(await getRelatedProductQuery.ExecutedAsync(productId));
        }

        [HttpGet("GetProductDetail")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductDetailAsync(int productId)
        {
            return new ObjectResult(await getProductDetailQuery.ExecutedAsync(productId));
        }

        [HttpGet("GetRates")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRateAsync(int productId)
        {
            return new ObjectResult(await getRateQuery.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), productId));
        }

        [HttpGet("GetComments")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCommentAsync(int productId, int pagaNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getCommentQuery.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), productId, pagaNumber, pageSize));
        }

        [HttpGet("GetCategory")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoryAsync()
        {
            return new ObjectResult(await getCategoryQuery.ExecutedAsync());
        }

        [HttpGet("CreateComment")]
        [Authorize]
        public async Task<IActionResult> CreateCommentAsync(int productId, string content, int? parrentId = null)
        {
            return new ObjectResult(await createCommentCommand.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), productId, content, parrentId));
        }

        [HttpGet("CreateRate")]
        [Authorize]
        public async Task<IActionResult> CreateRateAsync(int productId, int point)
        {
            return new ObjectResult(await createRateCommand.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), productId, point));
        }
    }
}
