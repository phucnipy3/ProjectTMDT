using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Service.Product.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetComment
{
    public interface IGetCommentQuery
    {
        Task<PagedList<CommentViewModel>> ExecutedAsync(string userName, int productId, int pageNumber, int pageSize);
    }
}