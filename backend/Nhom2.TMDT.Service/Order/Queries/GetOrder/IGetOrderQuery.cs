using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Service.Order.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Order.Queries.GetOrder
{
    public interface IGetOrderQuery
    {
        Task<PagedList<OrderViewModel>> ExecutedAsync(int userId, string searchString, int status, int pageNumber, int pageSize);
    }
}