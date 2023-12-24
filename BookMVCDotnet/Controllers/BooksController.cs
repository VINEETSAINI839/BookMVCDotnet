using BookMVCDotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMVCDotnet.Controllers
{
    public class BooksController : Controller
    {
        // GET: BooksController
        public ActionResult Index()
        {
            return View(Book.GetAllBooks());
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            Book book=Book.GetBookDetails(id);
            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book,IFormCollection collection)
        {
            try
            {
                Book.AddBookDetails(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Book.GetBookDetails(id));
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book, IFormCollection collection)
        {
            try
            {
                Book.UpdateBookDetails(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = Book.GetBookDetails(id);
            return View(book);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Book.DeleteBookDetails(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
