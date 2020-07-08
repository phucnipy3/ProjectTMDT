using Nhom2.TMDT.Service.Product.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetRelatedProduct
{
    public interface IGetRelatedProductQuery
    {
        Task<List<ProductCardViewModel>> ExecutedAsync(int productId);
    }
}