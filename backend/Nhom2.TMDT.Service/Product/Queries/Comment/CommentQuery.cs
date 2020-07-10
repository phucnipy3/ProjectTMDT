using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Queries.Comment
{
    public class CommentQuery : ICommentQuery
    {
        private readonly ApplicationContext db;

        public CommentQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(string userName, int productId, string content, int? parrentId)
        {
            try
            {
                var user = await db.Users.Where(x => x.UserName == userName).SingleOrDefaultAsync();

                await db.Comments.AddAsync(new Data.Entities.Comment()
                {
                    ProductId = productId,
                    Content = content.Trim(),
                    CreatedBy = user.Id,
                    ParentId = parrentId
                });

                await db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return true;
            }
        }
    }
}
