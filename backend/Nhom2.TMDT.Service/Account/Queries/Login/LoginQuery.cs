using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Encryption;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Login.Queries
{
    public class LoginQuery : ILoginQuery
    {
        private readonly ApplicationContext db;

        public LoginQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<LoginViewModel> ExecutedAsync(string userName, string password)
        {
            LoginViewModel data = new LoginViewModel();
            data.Authenticated = false;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                string passwordEncrypt = await Task.Run(() => new Encryption().EncryptionMD5(password.Trim()));
                bool exists = await db.Users.AnyAsync(x => x.UserName == userName.Trim() && x.Password == passwordEncrypt);

                if (exists)
                {
                    data = await db.Users.Where(x => x.UserName == userName.Trim() && x.Password == passwordEncrypt).Select(x => new LoginViewModel()
                    {
                        Authenticated = true,
                        Role = x.Role.GetValueOrDefault()
                    }).SingleOrDefaultAsync();
                }    
            }

            return data;
        }
    }
}
