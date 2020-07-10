using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.CategoryManager.Add
{
    public class AddCategoryQuery : IAddCategoryQuery
    {
        private readonly ApplicationContext db;

        public AddCategoryQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(Category category)
        {
            try
            {
                await db.Categories.AddAsync(category);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
