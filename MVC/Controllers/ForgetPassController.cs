using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ForgetPassController : ApplicationController
    {
        //private ApplicationContext db = new ApplicationContext();
        // GET: ForgetPass
        [HttpPost]
        public ActionResult ForgetPass(ForgetPassViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserHelper.GetUsers().FirstOrDefault(x => x.UserID == model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Email not exist!");
                    return PartialView("../Shared/ForgetPass", model);
                }

                user.Verification = new Random().Next(100000, 999999).ToString();
                user.ExprireTime = DateTime.Now.AddMinutes(5);
                UserHelper.UpdateUser(user);

                var mail = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("phucnipy3@gmail.com", "PhucNipy1999xyz"),
                    EnableSsl = true
                };

                var masage = new MailMessage();
                masage.From = new MailAddress("phucnipy3@gmail.com");
                masage.ReplyToList.Add("phucnipy3@gmail.com");
                masage.To.Add(new MailAddress(model.Email));
                masage.Subject = "Change password";
                masage.Body = "We send mail from admin. " +
                              "Your vertification code is " + user.Verification + ". Enter this code to change password. Thank you!";
                masage.IsBodyHtml = true;
                mail.Send(masage);
                return Content("success," + user.UserID);
            }
            return PartialView("../Shared/ForgetPass", model);
        }
        [HttpGet]
        public ActionResult ChangePassword(string userId)
        {
            ViewBag.UserId = userId;
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string userId,string password, string rePassword, string code)
        {
            userId = userId.Trim();
            if (UserHelper.CheckValidCode(userId, code))
            {
                if (password == rePassword && UserHelper.ChangePassword(userId, password))
                {
                    return Redirect("/");
                }
            } 
            ViewBag.UserId = userId;
            return View();
        }
    }
}