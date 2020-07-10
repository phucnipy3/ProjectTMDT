using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.CategoryManager.Delete
{
    public class DeleteCategoryQuery : IDeleteCategoryQuery
    {
        private readonly ApplicationContext db;

        public DeleteCategoryQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int categoryId)
        {
            try
            {
                var category = await db.Categories.Where(x => x.Id == categoryId).SingleOrDefaultAsync();
                if (category == null)
                {
                    category.Status = false;
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
