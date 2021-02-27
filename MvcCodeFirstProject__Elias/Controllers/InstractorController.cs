using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Add new namespase
using System.Threading.Tasks;
using AutoMapper;
using MvcCodeFirstProject__Elias.ViewModels;
using System.Net;
using System.Data.Entity;
using PagedList;
using MvcCodeFirstProject__Elias.Models;

namespace MvcCodeFirstProject__Elias.Controllers
{
    public class InstractorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Instractor
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else { searchString = currentFilter; }
            ViewBag.CurrentFilter = searchString;
            var instractors = from s in db.Instractors
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                instractors = instractors.Where(s => s.InstractorName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    instractors = instractors.OrderByDescending(s => s.InstractorName);
                    break;
                default:
                    instractors = instractors.OrderBy(s => s.InstractorName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(instractors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Details
        //[Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = db.Instractors.Single(t => t.InstractorID == id);
            var instractor = Mapper.Map<Instractor, InstractorVM>(query);
            if (instractor == null)
            {
                return HttpNotFound();
            }
            return View(instractor);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstractorVM instractorVM)
        {
            if (ModelState.IsValid)
            {
                var instractor = Mapper.Map<Instractor>(instractorVM);
                db.Instractors.Add(instractor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instractorVM);
        }

        // GET: Edit
        public ActionResult Edit(int? id)
        {
            var query = db.Instractors.Single(t => t.InstractorID == id);
            var instractor = Mapper.Map<Instractor, InstractorVM>(query);
            return View(instractor);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstractorVM instractorVM)
        {
            if (ModelState.IsValid)
            {
                var instractor = Mapper.Map<Instractor>(instractorVM);
                db.Entry(instractor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instractorVM);
        }

        // GET: Delete
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            var query = db.Instractors.Single(t => t.InstractorID == id);
            var instractor = Mapper.Map<Instractor, InstractorVM>(query);
            return View(instractor);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, InstractorVM instractorVM)
        {
            var query = db.Instractors.Single(t => t.InstractorID == id);
            var instractor = Mapper.Map<Instractor, InstractorVM>(query);
            db.Instractors.Remove(query);  // 
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