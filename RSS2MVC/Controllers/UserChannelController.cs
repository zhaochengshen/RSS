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
    public class UserChannelController : Controller
    {
        private UserChannelContext db = new UserChannelContext();

        // GET: UserChannel
        public ActionResult Index()
        {
            return View(db.UserChannelModels.ToList());
        }

        // GET: UserChannel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserChannelModel userChannelModel = db.UserChannelModels.Find(id);
            if (userChannelModel == null)
            {
                return HttpNotFound();
            }
            return View(userChannelModel);
        }

        // GET: UserChannel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserChannel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,ChannelID")] UserChannelModel userChannelModel)
        {
            if (ModelState.IsValid)
            {
                db.UserChannelModels.Add(userChannelModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userChannelModel);
        }

        // GET: UserChannel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserChannelModel userChannelModel = db.UserChannelModels.Find(id);
            if (userChannelModel == null)
            {
                return HttpNotFound();
            }
            return View(userChannelModel);
        }

        // POST: UserChannel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,ChannelID")] UserChannelModel userChannelModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userChannelModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userChannelModel);
        }

        // GET: UserChannel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserChannelModel userChannelModel = db.UserChannelModels.Find(id);
            if (userChannelModel == null)
            {
                return HttpNotFound();
            }
            return View(userChannelModel);
        }

        // POST: UserChannel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserChannelModel userChannelModel = db.UserChannelModels.Find(id);
            db.UserChannelModels.Remove(userChannelModel);
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
