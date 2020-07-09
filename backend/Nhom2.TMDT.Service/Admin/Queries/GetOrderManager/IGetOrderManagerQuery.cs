using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Service.Admin.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.GetOrderManager
{
    public interface IGetOrderManagerQuery
    {
        Task<PagedList<OrderManagerViewModel>> ExecutedAsync(string searchString, int pageNumber, int pageSize);
    }
}