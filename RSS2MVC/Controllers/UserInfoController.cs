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
    public class UserInfoController : Controller
    {
        private UserInfoContext db = new UserInfoContext();

        // GET: UserInfo
        public ActionResult Index()
        {
            return View(db.UserInfoModels.ToList());
        }

        // GET: UserInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfoModel userInfoModel = db.UserInfoModels.Find(id);
            if (userInfoModel == null)
            {
                return HttpNotFound();
            }
            return View(userInfoModel);
        }

        // GET: UserInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,UserPwd,Email,CreateDate,LastLoginDate")] UserInfoModel userInfoModel)
        {
            if (ModelState.IsValid)
            {
                db.UserInfoModels.Add(userInfoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfoModel);
        }

        // GET: UserInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfoModel userInfoModel = db.UserInfoModels.Find(id);
            if (userInfoModel == null)
            {
                return HttpNotFound();
            }
            return View(userInfoModel);
        }

        // POST: UserInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,UserPwd,Email,CreateDate,LastLoginDate")] UserInfoModel userInfoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfoModel);
        }

        // GET: UserInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfoModel userInfoModel = db.UserInfoModels.Find(id);
            if (userInfoModel == null)
            {
                return HttpNotFound();
            }
            return View(userInfoModel);
        }

        // POST: UserInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfoModel userInfoModel = db.UserInfoModels.Find(id);
            db.UserInfoModels.Remove(userInfoModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
