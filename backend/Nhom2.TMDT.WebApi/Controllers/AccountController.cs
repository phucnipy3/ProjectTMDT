using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.Commands.ActiveAccount;
using Nhom2.TMDT.Service.Account.Commands.ChangePassword;
using Nhom2.TMDT.Service.Account.Commands.ForgetPassword;
using Nhom2.TMDT.Service.Account.Commands.GetNewPassword;
using Nhom2.TMDT.Service.Account.Commands.Register;
using Nhom2.TMDT.Service.Account.Commands.UpdateProfile;
using Nhom2.TMDT.Service.Account.Login.Queries;
using Nhom2.TMDT.Service.Account.ViewModels;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly ApplicationContext db;
        private readonly ILoginQuery loginQuery;
        private readonly IRegisterCommand registerCommand;
        private readonly IForgetPasswordCommand forgetPasswordCommand;
        private readonly IActiveAccountCommand activeAccountCommand;
        private readonly IUpdateProfileCommand updateProfileCommand;
        private readonly IChangePasswordCommand changePasswordCommand;
        private readonly IGetNewPasswordCommand getNewPasswordCommand;

        public AccountController(ApplicationContext db, ILoginQuery loginQuery, IRegisterCommand registerCommand, IForgetPasswordCommand forgetPasswordCommand, IActiveAccountCommand activeAccountCommand, IUpdateProfileCommand updateProfileCommand, IChangePasswordCommand changePasswordCommand, IGetNewPasswordCommand getNewPasswordCommand)
        {
            this.db = db;
            this.loginQuery = loginQuery;
            this.registerCommand = registerCommand;
            this.forgetPasswordCommand = forgetPasswordCommand;
            this.activeAccountCommand = activeAccountCommand;
            this.updateProfileCommand = updateProfileCommand;
            this.changePasswordCommand = changePasswordCommand;
            this.getNewPasswordCommand = getNewPasswordCommand;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                User user = await loginQuery.ExecutedAsync(loginViewModel);

                if (user != null)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        new Claim(ClaimTypes.Uri, user.Image ?? ""),
                        new Claim(ClaimTypes.Name, user.Name ?? ""),
                        new Claim(ClaimTypes.NameIdentifier, user.Username),
                        new Claim(ClaimTypes.Role, ((Role)user.Role).ToString())
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return new ObjectResult(new UserViewModel() { FullName = user.Name, Image = user.Image });
                }
                return new ObjectResult(null);
            }
            catch (Exception ex)
            {
                return new ObjectResult(null);
            }
        }

        [HttpGet("Logout")]
        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return new ObjectResult(true);
        }

        [HttpGet("GetProfile")]
        [Authorize]
        public async Task<IActionResult> GetProfileAsync()
        {
            return new ObjectResult(await db.Users.Where(x => x.Id == int.Parse(User.FindFirstValue(ClaimTypes.Sid))).Select(x => new ProfileViewModel() 
            {
                Id = x.Id,
                Username = x.Username,
                FullName = x.Username,
                IsMale = x.Sex == 0,
                PhoneNumber = x.ShipmentDetails.First().PhoneNumber,
                Email = x.ShipmentDetails.First().Email,
                Address = x.ShipmentDetails.First().Address
            }).FirstOrDefaultAsync());
        }

        [HttpPost("UpdateProfile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfileAsync([FromBody]ProfileViewModel profileViewModel)
        {
            return new ObjectResult(await updateProfileCommand.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), profileViewModel));
        }

        [HttpGet("Authentication")]
        [AllowAnonymous]
        public IActionResult Authentication(int role = 3)
        {
            if (!User.Identity.IsAuthenticated)
                return new ObjectResult(null);

            int userRole = (int)(Role)Enum.Parse(typeof(Role), User.FindFirstValue(ClaimTypes.Role));
            if (userRole > 0 && userRole <= role)
                return new ObjectResult(new UserViewModel() { FullName = User.FindFirstValue(ClaimTypes.Name), Image = User.FindFirstValue(ClaimTypes.Uri) });
            return new ObjectResult(null);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel registerViewModel)
        {
            return new ObjectResult(await registerCommand.ExecutedAsync(registerViewModel));
        }

        [HttpPost("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordViewModel changePasswordViewModel)
        {
            return new ObjectResult(await changePasswordCommand.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), changePasswordViewModel));
        }

        [HttpPost("GetNewPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> GetNewPasswordAsync([FromBody] NewPasswordViewModel newPasswordViewModel)
        {
            return new ObjectResult(await getNewPasswordCommand.ExecutedAsync(int.Parse(User.FindFirstValue(ClaimTypes.Sid)), newPasswordViewModel));
        }

        [HttpPost("ForgerPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgerPasswordAsync([FromBody] string email)
        {
            return new ObjectResult(await forgetPasswordCommand.ExecutedAsync(email));
        }

        [HttpPost("ActivateAccount")]
        [AllowAnonymous]
        public async Task<IActionResult> ActivateAccountAsync([FromBody] ActiveViewModel activeViewModel)
        {
            if (!await activeAccountCommand.ExecutedAsync(activeViewModel))
                return new ObjectResult(false);

            try
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Username == activeViewModel.Username);

                ClaimsIdentity identity = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Uri, user.Image ?? ""),
                new Claim(ClaimTypes.Name, user.Name ?? ""),
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, ((Role)user.Role).ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return new ObjectResult(true);
            }
            catch (Exception ex)
            {
                return new ObjectResult(false);
            }
        }
    }
}
