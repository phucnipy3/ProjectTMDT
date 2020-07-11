using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Commands.UpdateComment
{
    public interface IUpdateCommentCommand
    {
        Task<bool> ExecutedAsync(int userId, int commentId, string content);
    }
}