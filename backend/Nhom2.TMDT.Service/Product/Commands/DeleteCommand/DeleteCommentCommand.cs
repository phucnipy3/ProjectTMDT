using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Commands.DeleteCommand
{
    public class DeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly ApplicationContext db;

        public DeleteCommentCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId, int commentId)
        {
            try
            {
                var comment = await db.Comments.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == commentId);

                if (comment == null)
                    return false;
                if (comment.User.Id != userId)
                    return false;

                db.Entry(comment).State = EntityState.Deleted;

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
