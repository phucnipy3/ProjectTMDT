using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.GetRole
{
    public class GetRoleQuery : IGetRoleQuery
    {
        private readonly ApplicationContext db;

        public GetRoleQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<int> ExecutedAsync(string userName)
        {
            var data = await db.Users.Where(x => x.UserName == userName.Trim()).SingleOrDefaultAsync();

            if (data == null)
            {
                return -1;
            }
            return data.Role.GetValueOrDefault();
        }
    }
}
