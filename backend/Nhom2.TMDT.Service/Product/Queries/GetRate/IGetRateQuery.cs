using Nhom2.TMDT.Service.Product.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetRate
{
    public interface IGetRateQuery
    {
        Task<RateViewModel> ExecutedAsync(int userId, int productId);
    }
}