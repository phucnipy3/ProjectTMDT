using Nhom2.TMDT.Service.Home.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Home.Queries.GetSlideProduct
{
    public interface IGetSlideProductHotQuery
    {
        Task<List<ProductSlideViewModel>> ExecutedAsync();
    }
}