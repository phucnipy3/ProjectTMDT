using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.ProductManager.Add
{
    public interface IAddProductCommand
    {
        Task<bool> ExecutedAsync(Data.Entities.Product product);
    }
}