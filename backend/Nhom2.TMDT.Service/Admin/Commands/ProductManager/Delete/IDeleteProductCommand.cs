using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.ProductManager.Delete
{
    public interface IDeleteProductCommand
    {
        Task<bool> ExecutedAsync(int productId);
    }
}