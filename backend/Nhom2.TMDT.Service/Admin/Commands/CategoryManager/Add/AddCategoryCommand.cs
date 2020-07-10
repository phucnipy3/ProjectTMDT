using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using System;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.CategoryManager.Add
{
    public class AddCategoryCommand : IAddCategoryCommand
    {
        private readonly ApplicationContext db;

        public AddCategoryCommand(ApplicationContext db)
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
