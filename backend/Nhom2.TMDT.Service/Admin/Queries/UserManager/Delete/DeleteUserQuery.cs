using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Admin.Queries.UserManager.Delete
{
    public class DeleteUserQuery : IDeleteUserQuery
    {
        private readonly ApplicationContext db;

        public DeleteUserQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId)
        {
            try
            {
                var user = await db.Users.Where(x => x.Id == userId).SingleOrDefaultAsync();
                if (user == null)
                {
                    user.Status = false;
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
