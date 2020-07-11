using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Encryption;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Login.Queries
{
    public class LoginQuery : ILoginQuery
    {
        private readonly ApplicationContext db;
        private Encryption encryption;

        public LoginQuery(ApplicationContext db)
        {
            this.db = db;
            encryption = new Encryption();
        }

        public async Task<User> ExecutedAsync(LoginViewModel loginViewModel)
        {
            if (string.IsNullOrEmpty(loginViewModel.Username) || string.IsNullOrEmpty(loginViewModel.Password))
                return null;

            string passwordEncrypt = encryption.EncryptionMD5(loginViewModel.Password);

            var data = await db.Users.Where(x => x.Username == loginViewModel.Username && x.Password == passwordEncrypt && x.Active == true).FirstOrDefaultAsync();

            return data;
        }
    }
}
