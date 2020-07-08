using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Service.Product.Queries.GetComment;
using Nhom2.TMDT.Service.Product.Queries.GetProduct;
using Nhom2.TMDT.Service.Product.Queries.GetProductDetail;
using Nhom2.TMDT.Service.Product.Queries.GetRate;
using Nhom2.TMDT.Service.Product.Queries.GetRelatedProduct;
using System.Threading.Tasks;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductController : Controller
    {
        public readonly IGetProductQuery getProductQuery;
        public readonly IGetRelatedProductQuery getRelatedProductQuery;
        public readonly IGetProductDetailQuery getProductDetailQuery;
        public readonly IGetRateQuery getRateQuery;
        public readonly IGetCommentQuery getCommentQuery;

        public ProductController(IGetProductQuery getProductQuery, IGetRelatedProductQuery getRelatedProductQuery, IGetProductDetailQuery getProductDetailQuery, IGetRateQuery getRateQuery, IGetCommentQuery getCommentQuery)
        {
            this.getProductQuery = getProductQuery;
            this.getRelatedProductQuery = getRelatedProductQuery;
            this.getProductDetailQuery = getProductDetailQuery;
            this.getRateQuery = getRateQuery;
            this.getCommentQuery = getCommentQuery;
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProductAsync(int category, string searchString, int pageNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getProductQuery.ExecutedAsync(category, searchString, pageNumber, pageSize));
        }

        [HttpGet("GetRelatedProduct")]
        public async Task<IActionResult> GetRelatedProductAsync(int productId)
        {
            return new ObjectResult(await getRelatedProductQuery.ExecutedAsync(productId));
        }

        [HttpGet("GetProductDetail")]
        public async Task<IActionResult> GetProductDetailAsync(int productId)
        {
            return new ObjectResult(await getProductDetailQuery.ExecutedAsync(productId));
        }

        [HttpGet("GetRate")]
        public async Task<IActionResult> GetRateAsync(int productId)
        {
            return new ObjectResult(await getRateQuery.ExecutedAsync(User.Identity.Name, productId));
        }

        [HttpGet("GetComment")]
        public async Task<IActionResult> GetCommentAsync(int productId, int pagaNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getCommentQuery.ExecutedAsync(User.Identity.Name, productId, pagaNumber, pageSize));
        }
    }
}
