using Nhom2.TMDT.Data.Services;
using System;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Product.Commands.CreateComment
{
    public class CreateCommentCommand : ICreateCommentCommand
    {
        private readonly ApplicationContext db;

        public CreateCommentCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId, int productId, string content, int? parentId)
        {
            try
            {
                await db.Comments.AddAsync(new Data.Entities.Comment()
                {
                    ProductId = productId,
                    Content = content.Trim(),
                    CreatedBy = userId,
                    ParentId = parentId
                });

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
