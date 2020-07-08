using Nhom2.TMDT.Service.Product.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetProductDetail
{
    public interface IGetProductDetailQuery
    {
        Task<ProductViewModel> ExecutedAsync(int productId);
    }
}