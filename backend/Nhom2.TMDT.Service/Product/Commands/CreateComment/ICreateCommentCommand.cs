using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Commands.CreateComment
{
    public interface ICreateCommentCommand
    {
        Task<bool> ExecutedAsync(int userId, int productId, string content, int? parrentId);
    }
}