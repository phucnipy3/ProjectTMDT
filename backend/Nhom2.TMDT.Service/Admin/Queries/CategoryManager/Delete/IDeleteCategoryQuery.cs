using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.CategoryManager.Delete
{
    public interface IDeleteCategoryQuery
    {
        Task<bool> ExecutedAsync(int categoryId);
    }
}