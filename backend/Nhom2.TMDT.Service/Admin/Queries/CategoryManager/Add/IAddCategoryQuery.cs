using Nhom2.TMDT.Data.Entities;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.CategoryManager.Add
{
    public interface IAddCategoryQuery
    {
        Task<bool> ExecutedAsync(Category category);
    }
}