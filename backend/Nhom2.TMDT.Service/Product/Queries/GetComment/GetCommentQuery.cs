using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.PagedList;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Product.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.GetComment
{
    public class GetCommentQuery : IGetCommentQuery
    {
        private readonly ApplicationContext db;

        public GetCommentQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<PagedList<CommentViewModel>> ExecutedAsync(int userId, int productId, int pageNumber, int pageSize)
        {
            var table = db.Comments.Where(x => x.ProductId == productId && !x.ParentId.HasValue).OrderByDescending(x => x.CreatedDate).Select(x => new CommentViewModel()
            {
                Id = x.Id,
                Author = x.User.Name,
                Image = x.User.Image,
                Content = x.Content,
                Time = x.CreatedDate.GetValueOrDefault().ToString("HH:mm"),
                Date = x.CreatedDate.GetValueOrDefault().ToString("dd/MM/yyyy"),
                Children = x.Children.OrderByDescending(y => y.CreatedDate).Select(y => new CommentViewModel()
                {
                    Id = y.Id,
                    Author = y.User.Name,
                    Image = y.User.Image,
                    Content = y.Content,
                    Time = y.CreatedDate.GetValueOrDefault().ToString("HH:mm"),
                    Date = y.CreatedDate.GetValueOrDefault().ToString("dd/MM/yyyy"),
                    CanDelete = y.CreatedBy == userId,
                    Manager = y.User.Role == 1 || y.User.Role == 2
                }).ToList(),
                CanDelete = x.CreatedBy == userId,
                Manager = x.User.Role == 1 || x.User.Role == 2
            });

            PagedList<CommentViewModel> data = new PagedList<CommentViewModel>();

            data.Items = await table.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            data.PageNumber = pageNumber;
            data.PageSize = pageSize;
            data.TotalCount = await table.CountAsync();

            return data;
        }
    }
}
