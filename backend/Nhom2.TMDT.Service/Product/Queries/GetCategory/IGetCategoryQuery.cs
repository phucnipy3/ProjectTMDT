using Nhom2.TMDT.Service.Product.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetCategory
{
    public interface IGetCategoryQuery
    {
        Task<List<CategoryViewModel>> ExecutedAsync();
    }
}