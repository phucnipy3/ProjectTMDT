using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.ProductManager.Delete
{
    public interface IDeleteProductQuery
    {
        Task<bool> ExecutedAsync(int productId);
    }
}