using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Commands.CreateRate
{
    public interface ICreateRateCommand
    {
        Task<bool> ExecutedAsync(int userId, int productId, int point);
    }
}