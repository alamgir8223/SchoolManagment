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
    public class TeacherRegistrationsController : Controller
    {
        private SchoolDatabaseEntities db = new SchoolDatabaseEntities();

     public ActionResult View2()
        { return View(db.TeacherRegistrations.ToList()); }


        // GET: TeacherRegistrations
        [Authorize]
        public ActionResult Index()
        {
            return View(db.TeacherRegistrations.ToList());
        }

        // GET: TeacherRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherRegistration teacherRegistration = db.TeacherRegistrations.Find(id);
            if (teacherRegistration == null)
            {
                return HttpNotFound();
            }
            return View(teacherRegistration);
        }

        // GET: TeacherRegistrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeacherName,JoiningDate,Graduation,Subject")] TeacherRegistration teacherRegistration)
        {
            if (ModelState.IsValid)
            {
                db.TeacherRegistrations.Add(teacherRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherRegistration);
        }

        // GET: TeacherRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherRegistration teacherRegistration = db.TeacherRegistrations.Find(id);
            if (teacherRegistration == null)
            {
                return HttpNotFound();
            }
            return View(teacherRegistration);
        }

        // POST: TeacherRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeacherName,JoiningDate,Graduation,Subject")] TeacherRegistration teacherRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherRegistration);
        }

        // GET: TeacherRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherRegistration teacherRegistration = db.TeacherRegistrations.Find(id);
            if (teacherRegistration == null)
            {
                return HttpNotFound();
            }
            return View(teacherRegistration);
        }

        // POST: TeacherRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherRegistration teacherRegistration = db.TeacherRegistrations.Find(id);
            db.TeacherRegistrations.Remove(teacherRegistration);
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
