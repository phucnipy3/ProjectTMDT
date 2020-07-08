using Nhom2.TMDT.Service.Home.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Home.Queries.GetSlideProductNew
{
    public interface IGetSlideProductNewQuery
    {
        Task<List<ProductSlideViewModel>> ExecutedAsync();
    }
}