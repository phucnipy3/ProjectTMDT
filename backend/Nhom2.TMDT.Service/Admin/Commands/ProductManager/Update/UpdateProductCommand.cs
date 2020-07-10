using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.ProductManager.Update
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly ApplicationContext db;

        public UpdateProductCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(Data.Entities.Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
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
