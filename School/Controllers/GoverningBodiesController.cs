using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School.Models;

namespace School.Controllers
{
    public class GoverningBodiesController : Controller
    {
        private SchoolDatabaseEntities db = new SchoolDatabaseEntities();
        public ActionResult Index2()
        {
            return View(db.GoverningBodies.ToList());
        }
        // GET: GoverningBodies
        [Authorize]
        public ActionResult Index()
        {
            return View(db.GoverningBodies.ToList());
        }

        // GET: GoverningBodies/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoverningBody governingBody = db.GoverningBodies.Find(id);
            if (governingBody == null)
            {
                return HttpNotFound();
            }
            return View(governingBody);
        }

        // GET: GoverningBodies/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoverningBodies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Position")] GoverningBody governingBody)
        {
            if (ModelState.IsValid)
            {
                db.GoverningBodies.Add(governingBody);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(governingBody);
        }

        // GET: GoverningBodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoverningBody governingBody = db.GoverningBodies.Find(id);
            if (governingBody == null)
            {
                return HttpNotFound();
            }
            return View(governingBody);
        }

        // POST: GoverningBodies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position")] GoverningBody governingBody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(governingBody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(governingBody);
        }

        // GET: GoverningBodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoverningBody governingBody = db.GoverningBodies.Find(id);
            if (governingBody == null)
            {
                return HttpNotFound();
            }
            return View(governingBody);
        }

        // POST: GoverningBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoverningBody governingBody = db.GoverningBodies.Find(id);
            db.GoverningBodies.Remove(governingBody);
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
