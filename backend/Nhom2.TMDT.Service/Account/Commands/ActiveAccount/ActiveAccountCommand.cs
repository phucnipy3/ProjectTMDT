using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.ActiveAccount
{
    public class ActiveAccountCommand : IActiveAccountCommand
    {
        private readonly ApplicationContext db;

        public ActiveAccountCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(ActiveViewModel activeViewModel)
        {
            return await db.Users.AnyAsync(x => x.Username == activeViewModel.Username && x.Verification == activeViewModel.Code);
        }
    }
}
