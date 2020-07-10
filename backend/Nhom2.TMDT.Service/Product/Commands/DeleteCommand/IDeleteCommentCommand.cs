using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Commands.DeleteCommand
{
    public interface IDeleteCommentCommand
    {
        Task<bool> ExecutedAsync(int userId, int commentId);
    }
}