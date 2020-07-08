using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Service.Product.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetProduct
{
    public interface IGetProductQuery
    {
        Task<PagedList<ProductCardViewModel>> ExecutedAsync(int category, string searchString, int pageNumber = 1, int pageSize = 10);
    }
}