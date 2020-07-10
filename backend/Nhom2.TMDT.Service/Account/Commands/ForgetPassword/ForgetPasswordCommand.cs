using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Mail.SendMail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.ForgetPassword
{
    public class ForgetPasswordCommand : IForgetPasswordCommand
    {
        private readonly ApplicationContext db;
        private readonly ISendMail sendMail;

        public ForgetPasswordCommand(ApplicationContext db, ISendMail sendMail)
        {
            this.db = db;
            this.sendMail = sendMail;
        }

        public async Task<bool> ExecutedAsync(string email)
        {
            try
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Username == email);
                if (user == null)
                    return false;

                user.Verification = new Random().Next(100000, 1000000).ToString();
                user.ExprireTime = DateTime.Now.AddMinutes(10);

                string body = File.ReadAllText("./Templates/MailVerificationTemplate.html");

                body = body.Replace("@Name", user.Name);
                body = body.Replace("@Code", user.Verification);
                body = body.Replace("@Time", user.ExprireTime.ToString());

                await sendMail.ExecutedAsync(user.Username, "Verification forget password", body);
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
