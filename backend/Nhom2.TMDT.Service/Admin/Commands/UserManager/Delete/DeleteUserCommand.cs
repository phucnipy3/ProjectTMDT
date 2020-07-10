using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.UserManager.Delete
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly ApplicationContext db;

        public DeleteUserCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId)
        {
            try
            {
                var user = await db.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (user == null)
                {
                    user.Status = false;
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
