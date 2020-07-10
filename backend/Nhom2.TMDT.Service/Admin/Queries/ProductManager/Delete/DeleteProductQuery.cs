using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.ProductManager.Delete
{
    public class DeleteProductQuery : IDeleteProductQuery
    {
        private readonly ApplicationContext db;

        public DeleteProductQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int productId)
        {
            try
            {
                var product = await db.Products.Where(x => x.Id == productId).SingleOrDefaultAsync();
                if (product == null)
                {
                    product.Status = false;
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
