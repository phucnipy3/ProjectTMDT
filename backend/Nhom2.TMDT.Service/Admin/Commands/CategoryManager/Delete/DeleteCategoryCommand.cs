using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.CategoryManager.Delete
{
    public class DeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly ApplicationContext db;

        public DeleteCategoryCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int categoryId)
        {
            try
            {
                var category = await db.Categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
                if (category == null)
                {
                    category.Status = false;
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
