using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Service.Admin.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.GetOrder
{
    public interface IGetOrderQuery
    {
        Task<PagedList<OrderViewModel>> ExecutedAsync(string userName, string searchString, int pageNumber, int pageSize);
    }
}