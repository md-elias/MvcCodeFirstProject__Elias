using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCodeFirstProject__Elias.Models;
using MvcCodeFirstProject__Elias.ViewModels;
using PagedList;

namespace ViewModelInMvc.Controllers
{
    [RoutePrefix("Book Info")]
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Book
        [Route("Home")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var books = from t in db.Books
                           select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(t => t.BookName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    books = books.OrderByDescending(t => t.BookName);
                    break;
                default:
                    books = books.OrderBy(t => t.BookName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookVM bookVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(bookVM.ImageFile.FileName);
                string extention = Path.GetExtension(bookVM.ImageFile.FileName);
                HttpPostedFileBase postedFile = bookVM.ImageFile;
                int length = postedFile.ContentLength;

                if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extention;
                        bookVM.ImagePath = "~/AppFiles/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName);
                        bookVM.ImageFile.SaveAs(fileName);
                        var Book = Mapper.Map<Book>(bookVM);

                        db.Books.Add(Book);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {

                            ModelState.Clear();
                            return RedirectToAction("Index", "Book");
                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data not inserted')</script>";
                        }
                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Image Size Should Less Than 1 MB')</script>";
                    }
                }
                else
                {
                    TempData["ExtentionMessage"] = "<script>alert('Format Not Supported')</script>";
                }
            }
            return View();


        }

        public ActionResult Edit(int? id)
        {
            var query = db.Books.Single(t => t.BookID == id);
            Session["Image"] = query.ImagePath;

            var Book = Mapper.Map<Book, BookVM>(query);
            return View(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookVM bookVM)
        {

            if (ModelState.IsValid == true)
            {
                if (bookVM.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(bookVM.ImageFile.FileName);
                    string extention = Path.GetExtension(bookVM.ImageFile.FileName);
                    HttpPostedFileBase postedFile = bookVM.ImageFile;
                    int length = postedFile.ContentLength;
                    if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extention;
                            bookVM.ImagePath = "~/AppFiles/Images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName);
                            bookVM.ImageFile.SaveAs(fileName);

                            var Book = Mapper.Map<Book>(bookVM);


                            db.Entry(Book).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                ModelState.Clear();
                                return RedirectToAction("Index", "Book");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size Should Less Than 1 MB')</script>";
                        }
                    }
                    else
                    {
                        TempData["ExtentionMessage"] = "<script>alert('Format Not Supported')</script>";
                    }
                }
                else
                {
                    bookVM.ImagePath = Session["Image"].ToString();
                    var Book = Mapper.Map<Book>(bookVM);

                    db.Entry(Book).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Book");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                    }
                }
            }
            return View();


        }


        public ActionResult Delete(int? id)
        {
            var query = db.Books.Single(t => t.BookID == id);
            var Book = Mapper.Map<Book, BookVM>(query);
            return View(Book);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, BookVM bookVM)
        {
            var query = db.Books.Single(t => t.BookID == id);
            var trainee = Mapper.Map<Book, BookVM>(query);
            db.Books.Remove(query);  // 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

