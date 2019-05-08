using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using netmvc_workshop.Models;

namespace netmvc_workshop.Controllers
{
    public class HomeController : Controller
    {
        BookdataEntities db = new BookdataEntities();

        // GET: Home
        public ActionResult Index()
        {
            var book = db.booklist.OrderBy(m => m.BOOK_ID).ToList();
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
}       [HttpPost]
        public ActionResult Create(booklist vbook)
        {
            db.booklist.Add(vbook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int BOOKID)
        {
            var bk = db.booklist.Where(m => m.BOOK_ID == BOOKID).FirstOrDefault();
            db.booklist.Remove(bk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int BOOKID)
        {
            var bk = db.booklist.Where(m => m.BOOK_ID == BOOKID).FirstOrDefault();
            return View(bk);
        } [HttpPost]
            public ActionResult Edit(booklist vbook)
        {
            int Bid = vbook.BOOK_ID;
            var bk = db.booklist.Where(m => m.BOOK_ID == Bid).FirstOrDefault();
            bk.BOOK_NAME = vbook.BOOK_NAME;
            bk.BOOK_CLASS = vbook.BOOK_CLASS;
            bk.BOOK_BORROW = vbook.BOOK_BORROW;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        }
      

    }
