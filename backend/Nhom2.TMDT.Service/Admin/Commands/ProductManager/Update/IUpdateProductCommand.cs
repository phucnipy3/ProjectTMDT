using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.ProductManager.Update
{
    public interface IUpdateProductCommand
    {
        Task<bool> ExecutedAsync(Data.Entities.Product product);
    }
}