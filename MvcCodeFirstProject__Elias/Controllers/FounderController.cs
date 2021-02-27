using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcCodeFirstProject__Elias.Models;

namespace MvcProject_Elias.Controllers
{
    public class FounderController : Controller
    {
        // GET: Founder
        private ApplicationDbContext _context;
        public FounderController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(_context.FounderInformations.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(FounderInformation user)
        {
            _context.FounderInformations.Add(user);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_context.FounderInformations.FirstOrDefault(x => x.FounderInformationID == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(FounderInformation user)
        {
            var data = _context.FounderInformations.FirstOrDefault(x => x.FounderInformationID == user.FounderInformationID);
            if (data != null)
            {
                data.Name = user.Name;
                data.State = user.State;
                data.Country = user.Country;
                data.Age = user.Age;
                _context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _context.FounderInformations.FirstOrDefault(x => x.FounderInformationID == ID);
            _context.FounderInformations.Remove(data);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}