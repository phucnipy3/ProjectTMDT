using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Encryption;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.GetNewPassword
{
    public class GetNewPasswordCommand : IGetNewPasswordCommand
    {
        private readonly ApplicationContext db;
        private Encryption encryption;

        public GetNewPasswordCommand(ApplicationContext db)
        {
            this.db = db;
            encryption = new Encryption();
        }

        public async Task<bool> ExecutedAsync(int userId, NewPasswordViewModel newPasswordViewModel)
        {
            try
            {
                var user = await db.Users.Where(x => x.Id == userId && x.Verification == newPasswordViewModel.Code && x.ExprireTime <= DateTime.Now).FirstOrDefaultAsync();

                if (user == null)
                    return false;

                user.Password = encryption.EncryptionMD5(newPasswordViewModel.NewPassword);

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
