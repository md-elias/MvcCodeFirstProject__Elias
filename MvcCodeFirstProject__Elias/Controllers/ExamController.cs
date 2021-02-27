using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCodeFirstProject__Elias.Models;


namespace MvcProject_Elias.Controllers
{
    public class ExamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Exam
        public ActionResult Index()
        {
            var examDetails = db.ExamDetails.Include(t => t.Students);
            return View(examDetails.ToList());
        }


        //public ActionResult Details(int id = 0)
        //{
        //    ExamDetail examdetail = db.ExamDetails.Find(id);
        //    if (examdetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(examdetail);
        //}

        //
        // GET: /Exam/Create

        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name");   //for dropdown
            return View();
        }

        //
        // POST: /Exam/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamDetail examdetail)
        {
            if (ModelState.IsValid)
            {
                db.ExamDetails.Add(examdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", examdetail.StudentId); //for dropdown
            return View(examdetail);
        }

        //
        // GET: /Exam/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExamDetail examdetail = db.ExamDetails.Find(id);
            if (examdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", examdetail.StudentId); //for dropdown
            return View(examdetail);
        }

        //
        // POST: /Exam/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamDetail examdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", examdetail.StudentId); //for dropdown
            return View(examdetail);
        }

        //
        // GET: /Exam/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExamDetail examdetail = db.ExamDetails.Find(id);
            if (examdetail == null)
            {
                return HttpNotFound();
            }
            return View(examdetail);
        }

        //
        // POST: /Exam/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamDetail examdetail = db.ExamDetails.Find(id);
            db.ExamDetails.Remove(examdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}