using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Encryption;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.ChangePassword
{
    public class ChangePasswordCommand : IChangePasswordCommand
    {
        private readonly ApplicationContext db;
        private Encryption encryption;

        public ChangePasswordCommand(ApplicationContext db)
        {
            this.db = db;
            encryption = new Encryption();
        }

        public async Task<bool> ExecutedAsync(int userId, ChangePasswordViewModel changePasswordViewModel)
        {
            try
            {
                string oldPasswordEncryt = encryption.EncryptionMD5(changePasswordViewModel.OldPassword);

                var user = await db.Users.Where(x => x.Id == userId && x.Password == oldPasswordEncryt).FirstOrDefaultAsync();

                if (user == null)
                    return false;

                user.Password = encryption.EncryptionMD5(changePasswordViewModel.NewPassword);

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
