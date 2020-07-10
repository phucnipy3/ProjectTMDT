using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.UserManager.Add
{
    public class AddUserQuery : IAddUserQuery
    {
        private readonly ApplicationContext db;

        public AddUserQuery(ApplicationContext db)
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
            catch
            {
                return false;
            }
        }
    }
}
