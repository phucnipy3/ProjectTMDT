using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using Nhom2.TMDT.Service.Mail.SendMail;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.Register
{
    public class RegisterQuery
    {
        private readonly ApplicationContext db;
        private readonly ISendMail sendMail;

        public RegisterQuery(ApplicationContext db, ISendMail sendMail)
        {
            this.db = db;
            this.sendMail = sendMail;
        }

        public async Task<bool> ExecutedAsync(RegisterViewModel registerViewModel)
        {
            try
            {
                if (await db.Users.AnyAsync(x => x.Username == registerViewModel.Email))
                    return false;

                if (await sendMail.ExecutedAsync(registerViewModel.Email, "", ""))
                {

                    await db.Users.AddAsync(new Data.Entities.User()
                    {
                        Username = registerViewModel.Email,
                        Name = registerViewModel.FullName,
                        Sex = registerViewModel.IsMale ? 0 : 1,

                    });

                    await db.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
