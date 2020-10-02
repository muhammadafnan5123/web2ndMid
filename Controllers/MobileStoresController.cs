using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MuhammadAfnan2ndMid.Data;
using MuhammadAfnan2ndMid.Models;

namespace MuhammadAfnan2ndMid.Controllers
{
    public class MobileStoresController : Controller
    {
        private MuhammadAfnan2ndMidContext db = new MuhammadAfnan2ndMidContext();

        // GET: MobileStores
        public ActionResult Index(string searchString)
        {
            var MobileStores = from m in db.MobileStores
                               select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                MobileStores = MobileStores.Where(s => s.MobileName.Contains(searchString));
            }
            return View(MobileStores);
        }

        // GET: MobileStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MobileStores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MobileName,Company,MadeIn,Price")] MobileStore mobileStore)
        {
            if (ModelState.IsValid)
            {
                db.MobileStores.Add(mobileStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobileStore);
        }

        // GET: MobileStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileStore mobileStore = db.MobileStores.Find(id);
            if (mobileStore == null)
            {
                return HttpNotFound();
            }
            return View(mobileStore);
        }

        // POST: MobileStores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MobileName,Company,MadeIn,Price")] MobileStore mobileStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobileStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobileStore);
        }

        // GET: MobileStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileStore mobileStore = db.MobileStores.Find(id);
            if (mobileStore == null)
            {
                return HttpNotFound();
            }
            return View(mobileStore);
        }

        // POST: MobileStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MobileStore mobileStore = db.MobileStores.Find(id);
            db.MobileStores.Remove(mobileStore);
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
