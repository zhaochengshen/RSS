using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSS2MVC.Models;

namespace RSS2MVC.Controllers
{
    public class AccountController : Controller
    {
        private UserInfoContext db = new UserInfoContext();


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserInfoModel userInfoModel)
        {
            string message = string.Empty;
            try
            {

                if (ModelState.IsValid)
                {
                    db.UserInfoModels.Add(userInfoModel);
                    db.SaveChanges();
                    ViewBag.Message = "用户创建成功！";
                }
            }
            catch
            {
                ViewBag.Message = "用户创建失败！";
            }
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
