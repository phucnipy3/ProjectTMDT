using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Common.Enums;
using Nhom2.TMDT.Data.Entities;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.Login.Queries;
using Nhom2.TMDT.Service.Account.Queries.ForgetPassword;
using Nhom2.TMDT.Service.Account.Queries.Register;
using Nhom2.TMDT.Service.Account.ViewModels;
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
        private readonly IRegisterQuery registerQuery;
        private readonly IForgetPasswordQuery forgetPasswordQuery;

        public AccountController(ApplicationContext db, ILoginQuery loginQuery, IRegisterQuery registerQuery, IForgetPasswordQuery forgetPasswordQuery)
        {
            this.db = db;
            this.loginQuery = loginQuery;
            this.registerQuery = registerQuery;
            this.forgetPasswordQuery = forgetPasswordQuery;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel loginViewModel)
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
            catch
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
            return new ObjectResult(await db.Users.Where(x => x.Id == int.Parse(User.FindFirstValue(ClaimTypes.Sid))).FirstOrDefaultAsync());
        }

        [HttpGet("Authentication")]
        [AllowAnonymous]
        public IActionResult Authentication(int role = 3)
        {
            if (!User.Identity.IsAuthenticated)
                return new ObjectResult(null);

            int userRole = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
            if (userRole > 0 && userRole <= role)
                return new ObjectResult(new UserViewModel() { FullName = User.FindFirstValue(ClaimTypes.Name), Image = User.FindFirstValue(ClaimTypes.Uri) });
            return new ObjectResult(null);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel registerViewModel)
        {
            return new ObjectResult(await registerQuery.ExecutedAsync(registerViewModel));
        }

        [HttpPost("ForgerPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgerPasswordAsync([FromBody]string email)
        {
            return new ObjectResult(await forgetPasswordQuery.ExecutedAsync(email));
        }
    }
}
