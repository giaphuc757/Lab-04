using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_04.Models;

namespace Lab_04.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        BookContext context = new BookContext();
        public ActionResult ListBook()
        {

            var listBook = context.Books.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();

            }
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Book book)
        {
            context.Books.AddOrUpdate(book);

            context.SaveChanges();

            return RedirectToAction("listBook");
        }

        public ActionResult Edit(int id)
        {
            Book book = context.Books.FirstOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();


            }
            return View(book);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            Book bookUpdate = context.Books.SingleOrDefault(p => p.ID == book.ID);
            if (bookUpdate != null)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }


        [Authorize]
        public ActionResult Delete(int id)
        {
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();

            }
            return View(book);
        }


        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            Book book = context.Books.FirstOrDefault(p => p.ID == id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }

    }
}