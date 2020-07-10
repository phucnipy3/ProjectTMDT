using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.Rate
{
    public interface IRateQuery
    {
        Task<bool> ExecutedAsync(string userName, int productId, int rate);
    }
}