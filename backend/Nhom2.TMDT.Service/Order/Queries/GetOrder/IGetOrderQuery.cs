using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Service.Order.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.GetOrder
{
    public interface IGetOrderQuery
    {
        Task<PagedList<OrderViewModel>> ExecutedAsync(string userName, string searchString, int pageNumber = 1, int pageSize = 10);
    }
}