using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Service.Product.Queries.Comment;
using Nhom2.TMDT.Service.Product.Queries.GetCategory;
using Nhom2.TMDT.Service.Product.Queries.GetComment;
using Nhom2.TMDT.Service.Product.Queries.GetProduct;
using Nhom2.TMDT.Service.Product.Queries.GetProductDetail;
using Nhom2.TMDT.Service.Product.Queries.GetRate;
using Nhom2.TMDT.Service.Product.Queries.GetRelatedProduct;
using Nhom2.TMDT.Service.Product.Queries.Rate;
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
        public readonly ICommentQuery commentQuery;
        public readonly IRateQuery rateQuery;

        public ProductController(IGetProductQuery getProductQuery, IGetRelatedProductQuery getRelatedProductQuery, IGetProductDetailQuery getProductDetailQuery, IGetRateQuery getRateQuery, IGetCommentQuery getCommentQuery, IGetCategoryQuery getCategoryQuery, ICommentQuery commentQuery, IRateQuery rateQuery)
        {
            this.getProductQuery = getProductQuery;
            this.getRelatedProductQuery = getRelatedProductQuery;
            this.getProductDetailQuery = getProductDetailQuery;
            this.getRateQuery = getRateQuery;
            this.getCommentQuery = getCommentQuery;
            this.getCategoryQuery = getCategoryQuery;
            this.commentQuery = commentQuery;
            this.rateQuery = rateQuery;
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

        [HttpGet("GetRate")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRateAsync(int productId)
        {
            return new ObjectResult(await getRateQuery.ExecutedAsync(User.Identity.Name, productId));
        }

        [HttpGet("GetComment")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCommentAsync(int productId, int pagaNumber = 1, int pageSize = 10)
        {
            return new ObjectResult(await getCommentQuery.ExecutedAsync(User.Identity.Name, productId, pagaNumber, pageSize));
        }

        [HttpGet("GetCategory")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoryAsync()
        {
            return new ObjectResult(await getCategoryQuery.ExecutedAsync());
        }

        [HttpGet("Comment")]
        [Authorize]
        public async Task<IActionResult> CommentAsync(int productId, string content, int? parrentId = null)
        {
            return new ObjectResult(await commentQuery.ExecutedAsync(User.Identity.Name, productId, content, parrentId));
        }

        [HttpGet("Rate")]
        [Authorize]
        public async Task<IActionResult> RateAsync(int productId, int rate)
        {
            return new ObjectResult(await rateQuery.ExecutedAsync(User.Identity.Name, productId, rate));
        }
    }
}
