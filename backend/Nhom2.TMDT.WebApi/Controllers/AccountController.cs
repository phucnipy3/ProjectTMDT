using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Service.Account.Login.Queries;
using Nhom2.TMDT.Service.Account.Queries.GetProfile;
using Nhom2.TMDT.Service.Account.Queries.GetRole;
using Nhom2.TMDT.Service.Account.Queries.GetUser;
using Nhom2.TMDT.Service.Account.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nhom2.TMDT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly ILoginQuery loginQuery;
        private readonly IGetProfileQuery getProfileQuery;
        private readonly IGetUserQuery getUserQuery;
        private readonly IGetRoleQuery getRoleQuery;

        public AccountController(ILoginQuery loginQuery, IGetProfileQuery getProfileQuery, IGetUserQuery getUserQuery, IGetRoleQuery getRoleQuery)
        {
            this.loginQuery = loginQuery;
            this.getProfileQuery = getProfileQuery;
            this.getUserQuery = getUserQuery;
            this.getRoleQuery = getRoleQuery;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(string userName, string password)
        {
            LoginViewModel login = await loginQuery.ExecutedAsync(userName, password);

            if (login.Authenticated)
            {
                ClaimsIdentity identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName.Trim()),
                    new Claim(ClaimTypes.Role, ((Role)login.Role).ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return new ObjectResult(await getUserQuery.ExecutedAsync(User.Identity.Name));
            }
            return new ObjectResult(null);
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
            return new ObjectResult(await getProfileQuery.ExecutedAsync(User.Identity.Name));
        }

        [HttpGet("Authentication")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticationAsync(int role = 3)
        {
            int userRole = await getRoleQuery.ExecutedAsync(User.Identity.Name);
            if (userRole > 0 && userRole <= role)
            {
                return new ObjectResult(await getUserQuery.ExecutedAsync(User.Identity.Name));
            }
            return new ObjectResult(null);
        }
    }
}
