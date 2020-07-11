using Nhom2.TMDT.Data.Entities;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.CategoryManager.Update
{
    public interface IUpdateCategoryCommand
    {
        Task<bool> ExecutedAsync(Category category);
    }
}