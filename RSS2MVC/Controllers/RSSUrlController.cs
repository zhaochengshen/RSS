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
    public class RSSUrlController : Controller
    {
        private RSSUrlContext db = new RSSUrlContext();

        // GET: RSSUrl
        public ActionResult Index()
        {
            return View(db.RSSUrlModels.ToList());
        }

        // GET: RSSUrl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSSUrlModel rSSUrlModel = db.RSSUrlModels.Find(id);
            if (rSSUrlModel == null)
            {
                return HttpNotFound();
            }
            return View(rSSUrlModel);
        }

        // GET: RSSUrl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RSSUrl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Url,CreateDate")] RSSUrlModel rSSUrlModel)
        {
            if (ModelState.IsValid)
            {
                db.RSSUrlModels.Add(rSSUrlModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rSSUrlModel);
        }

        // GET: RSSUrl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSSUrlModel rSSUrlModel = db.RSSUrlModels.Find(id);
            if (rSSUrlModel == null)
            {
                return HttpNotFound();
            }
            return View(rSSUrlModel);
        }

        // POST: RSSUrl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Url,CreateDate")] RSSUrlModel rSSUrlModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSSUrlModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rSSUrlModel);
        }

        // GET: RSSUrl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSSUrlModel rSSUrlModel = db.RSSUrlModels.Find(id);
            if (rSSUrlModel == null)
            {
                return HttpNotFound();
            }
            return View(rSSUrlModel);
        }

        // POST: RSSUrl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RSSUrlModel rSSUrlModel = db.RSSUrlModels.Find(id);
            db.RSSUrlModels.Remove(rSSUrlModel);
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

        public ContentResult Test(string strurl)
        {
            string content = ProcessRSSUrl.ProcessRSSItem(strurl);
            return Content(content);
        }
    }
}
