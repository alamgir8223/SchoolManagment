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
    public class StudentRegistrationsController : Controller
    {
        private SchoolDatabaseEntities db = new SchoolDatabaseEntities();

        // GET: StudentRegistrations
        [Authorize]
        public ActionResult Index()
        {
            return View(db.StudentRegistrations.ToList());
        }

        // GET: StudentRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            return View(studentRegistration);
        }
        [Authorize]
        public ActionResult Create2()
        {
            return View();
        }
        // GET: StudentRegistrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FathersName,MothersName,PresentAddress,ParmanentAddress,EnrollMentDate,Class,Religion")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                db.StudentRegistrations.Add(studentRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            return View(studentRegistration);
        }

        // POST: StudentRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FathersName,MothersName,PresentAddress,ParmanentAddress,EnrollMentDate,Class,Religion")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            return View(studentRegistration);
        }

        // POST: StudentRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            db.StudentRegistrations.Remove(studentRegistration);
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
