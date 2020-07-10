using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Encryption;
using Nhom2.TMDT.Common.Verification;
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
        private Encryption encryption;
        private Verification verification;

        public RegisterQuery(ApplicationContext db, ISendMail sendMail)
        {
            this.db = db;
            this.sendMail = sendMail;
            encryption = new Encryption();
            verification = new Verification();
        }

        public async Task<bool> ExecutedAsync(RegisterViewModel registerViewModel)
        {
            try
            {
                if (await db.Users.AnyAsync(x => x.Username == registerViewModel.Email))
                    return false;

                string verificationCode = verification.Random();

                if (await sendMail.ExecutedAsync(registerViewModel.Email, "", ""))
                {
                    string passwordEncrypt = encryption.EncryptionMD5(registerViewModel.Password);

                    await db.Users.AddAsync(new Data.Entities.User()
                    {
                        Username = registerViewModel.Email,
                        Name = registerViewModel.FullName,
                        Password = passwordEncrypt,
                        Sex = registerViewModel.IsMale ? 0 : 1,
                        ShipmentDetail = new Data.Entities.ShipmentDetail()
                        {
                            Address = registerViewModel.Address,
                            Email = registerViewModel.Email,
                            Phone = registerViewModel.Phone,
                        },
                        Verification = verificationCode
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
