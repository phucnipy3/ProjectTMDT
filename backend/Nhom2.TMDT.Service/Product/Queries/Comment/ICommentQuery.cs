using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.Comment
{
    public interface ICommentQuery
    {
        Task<bool> ExecutedAsync(string userName, int productId, string content, int? parrentId);
    }
}