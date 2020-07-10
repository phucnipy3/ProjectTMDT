using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.ProductManager.Add
{
    public interface IAddProductQuery
    {
        Task<bool> ExecutedAsync(Data.Entities.Product product);
    }
}