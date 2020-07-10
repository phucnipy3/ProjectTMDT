using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom2.TMDT.Service.Account.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IUpdateProfileCommand
    {
        private readonly ApplicationContext db;

        public UpdateProfileCommand(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<bool> ExecutedAsync(int userId, ProfileViewModel profileViewModel)
        {
            try
            {
                var user = await db.Users.Where(x => x.Id == userId).Include(x => x.ShipmentDetails).FirstOrDefaultAsync();

                if (user == null)
                    return false;

                user.Name = profileViewModel.FullName;
                user.Sex = profileViewModel.IsMale ? 0 : 1;
                user.ShipmentDetails.First().PhoneNumber = profileViewModel.PhoneNumber;
                user.ShipmentDetails.First().Email = profileViewModel.Email;
                user.ShipmentDetails.First().Address = profileViewModel.Address;

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
