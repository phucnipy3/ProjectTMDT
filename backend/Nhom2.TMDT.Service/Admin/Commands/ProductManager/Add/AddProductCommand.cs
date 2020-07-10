using Nhom2.TMDT.Data.Services;
using System;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.ProductManager.Add
{
    public class AddProductCommand : IAddProductCommand
    {
        private readonly ApplicationContext db;

        public AddProductCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(Data.Entities.Product product)
        {
            try
            {
                await db.Products.AddAsync(product);
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
