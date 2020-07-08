using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Service.Account.Login.Queries;
using Nhom2.TMDT.Service.Account.Queries.GetProfile;
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

        public AccountController(ILoginQuery loginQuery, IGetProfileQuery getProfileQuery)
        {
            this.loginQuery = loginQuery;
            this.getProfileQuery = getProfileQuery;
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

                return new ObjectResult(true);
            }
            return new ObjectResult(false);
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

        [HttpGet("Athorize")]
        [AllowAnonymous]
        public IActionResult Athorize(int role = 3)
        {

            return Unauthorized();
        }
    }
}
