using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnrollementApplication.Models;

namespace EnrollementApplication.Controllers
{
    public class EnrollementController : Controller
    {
        private EnrollementDBContext db = new EnrollementDBContext();

        // GET: Enrollement
        public ActionResult Index()
        {
            var enrollements = db.Enrollements.Include(e => e.Course).Include(e => e.Student);
            return View(enrollements.ToList());
        }

        // GET: Enrollement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollement enrollement = db.Enrollements.Find(id);
            if (enrollement == null)
            {
                return HttpNotFound();
            }
            return View(enrollement);
        }

        // GET: Enrollement/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Last");
            return View();
        }

        // POST: Enrollement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollementId,StudentId,CourseId,Grade")] Enrollement enrollement)
        {
            if (ModelState.IsValid)
            {
                db.Enrollements.Add(enrollement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", enrollement.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Last", enrollement.StudentId);
            return View(enrollement);
        }

        // GET: Enrollement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollement enrollement = db.Enrollements.Find(id);
            if (enrollement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", enrollement.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Last", enrollement.StudentId);
            return View(enrollement);
        }

        // POST: Enrollement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollementId,StudentId,CourseId,Grade")] Enrollement enrollement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", enrollement.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Last", enrollement.StudentId);
            return View(enrollement);
        }

        // GET: Enrollement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollement enrollement = db.Enrollements.Find(id);
            if (enrollement == null)
            {
                return HttpNotFound();
            }
            return View(enrollement);
        }

        // POST: Enrollement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollement enrollement = db.Enrollements.Find(id);
            db.Enrollements.Remove(enrollement);
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
