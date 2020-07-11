using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.ProductManager.Delete
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly ApplicationContext db;

        public DeleteProductCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int productId)
        {
            try
            {
                var product = await db.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
                if (product == null)
                {
                    product.Status = false;
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
