using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Commands.UpdateComment
{
    public class UpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly ApplicationContext db;

        public UpdateCommentCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId, int commentId, string content)
        {
            try
            {
                var comment = await db.Comments.FirstOrDefaultAsync(x => x.Id == commentId);

                if (comment == null)
                    return false;
                if (comment.CreatedBy != userId)
                    return false;

                comment.Content = content.Trim();

                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
    }
}
