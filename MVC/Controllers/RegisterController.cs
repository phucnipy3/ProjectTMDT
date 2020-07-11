using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace MVC.Controllers
{
    public class RegisterController : ApplicationController
    {
        private ApplicationContext db = new ApplicationContext();
        // GET: Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = new User()
                {
                    UserID = model.Email,
                    Name = model.FullName,
                    Sex = model.Sex,
                    Phone = model.Tel,
                    Password = model.Password,
                    Email = model.Email,
                    Role = "Customer",
                    Active = false,
                    Status = true,
                    Address = model.Address,
                    Verification = new Random().Next(100000, 999999).ToString(),
                    ExprireTime = DateTime.Now.AddMinutes(5)
                };
                if (UserHelper.AddUser(user))
                {
                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.SignOut();
                    }
                    var mail = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("phucnipy3@gmail.com", "PhucNipy1999xyz"),
                        EnableSsl = true
                    };

                    var masage = new MailMessage();
                    masage.From = new MailAddress("phucnipy3@gmail.com");
                    masage.ReplyToList.Add("phucnipy3@gmail.com");
                    masage.To.Add(new MailAddress(model.Email));
                    masage.Subject = "Confirm resgisitation";
                    masage.Body = "We send mail from admin. " +
                                  "Your vertification code is " + user.Verification + ". Enter this code to confirm your regisitation. Thank you!";
                    masage.IsBodyHtml = true;
                    mail.Send(masage);
                    return Content("success, "+ user.UserID);
                }
            }
            return PartialView("../Shared/Register", model);
        }

        [HttpGet]
        public ActionResult Confirm(string userId)
        {
            ViewBag.UserId = userId;
            return View();
        }
        [HttpPost]
        public ActionResult Confirm(string userId, string code)
        {
            userId = userId.Trim();
            if (UserHelper.CheckValidCode(userId, code))
            {
                FormsAuthentication.SetAuthCookie(userId, true);
                UserHelper.ModifyActive(userId, true);
                return Redirect("/");
            }
            ViewBag.UserId = userId;
            return View();
        }
    }
}