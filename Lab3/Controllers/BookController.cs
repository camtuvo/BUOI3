using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }

        [Authorize] //de dang nahp
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult CreateBook()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateBook(Book book)
        { 
            BookManagerContext context = new BookManagerContext();
            if (book.ID != null)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return this.CreateBook(book);
        }
        public ActionResult EditBook(int id)
        {
            BookManagerContext context = new BookManagerContext();
            var b = context.Books.FirstOrDefault(m => m.ID == id);
            return View(b);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            Book b = context.Books.FirstOrDefault(m => m.ID == book.ID);
            if(b != null)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return this.EditBook(book);
        }
        public ActionResult DeleteBook(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book b = context.Books.FirstOrDefault(m => m.ID == id);
            return View(b);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteBook(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            var b = context.Books.FirstOrDefault(m => m.ID == book.ID);
            if (b != null)
            {
                context.Books.Remove(b);
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return this.DeleteBook(book);
        }
    }
}