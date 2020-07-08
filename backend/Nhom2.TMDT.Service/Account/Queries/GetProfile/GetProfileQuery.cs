using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Queries.GetProfile
{
    public class GetProfileQuery : IGetProfileQuery
    {
        private readonly ApplicationContext db;

        public GetProfileQuery(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<ProfileViewModel> ExecutedAsync(string userName)
        {
            var data = await db.Users.Where(x => x.UserName.Trim() == userName.Trim()).Select(x => new ProfileViewModel()
            {
                UserName = x.UserName,
                FullName = x.Name,
                PhoneNumber = x.ShipmentDetail.Phone,
                Sex = x.Sex.GetValueOrDefault(),
                Email = x.ShipmentDetail.Email,
                Address = x.ShipmentDetail.Address
            }).SingleOrDefaultAsync();

            return data;
        }
    }
}
