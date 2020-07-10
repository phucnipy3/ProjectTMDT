using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using System;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Commands.UserManager.Add
{
    public class AddUserCommand : IAddUserCommand
    {
        private readonly ApplicationContext db;

        public AddUserCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(User user)
        {
            try
            {
                await db.Users.AddAsync(user);
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
