using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.CategoryManager.Delete
{
    public interface IDeleteCategoryCommand
    {
        Task<bool> ExecutedAsync(int categoryId);
    }
}