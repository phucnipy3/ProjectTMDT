using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.Models;

namespace MVC.Controllers
{
    public class LoginController : ApplicationController
    {
        // GET: Login
        private ApplicationContext db = new ApplicationContext();
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(UserHelper.IsValidUser(model.Email,model.Password))
                {
                    if(HttpContext.User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.SignOut();
                    }
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return Content("success");
                }
                ModelState.AddModelError("","Wrong e-mail or password");
            }
            return PartialView("../Shared/Login",model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home");
        }

    }
}