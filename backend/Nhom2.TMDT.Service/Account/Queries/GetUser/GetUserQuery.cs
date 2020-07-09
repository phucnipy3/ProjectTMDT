using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.GetUser
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly ApplicationContext db;

        public GetUserQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<UserViewModel> ExecutedAsync(string userName)
        {
            var data = await db.Users.Where(x => x.UserName == userName.Trim()).Select(x => new UserViewModel()
            {
                FullName = x.Name,
                Image = x.Image
            }).SingleOrDefaultAsync();

            return data;
        }
    }
}
