using Microsoft.AspNetCore.Mvc;
using SACBibliotecaGeneration.DataBase;
using SACBibliotecaGeneration.Models;
using System.Diagnostics;

namespace SACBibliotecaGeneration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (BookContext db = new BookContext())
            {
                List<Book> libri = db.Libri.ToList<Book>();

                return View(libri);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newBook);
            }
            using (BookContext db = new BookContext())
            {
                db.Libri.Add(newBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (BookContext db = new BookContext())
            {
                Book? bookToDelete = db.Libri.Where(book => book.Id == id).FirstOrDefault();
                if (bookToDelete != null)
                {
                    db.Remove(bookToDelete);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il Libro Non è Stato Trovato");
                }
            }
        }

        [HttpPost]
        public IActionResult Put(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("bookToPut", "ModifyBook");
            }
            using (BookContext db = new BookContext())
            {
                Book? bookToPut = db.Libri.Where(book => book.Id == id).FirstOrDefault();
                if (bookToPut != null)
                {
                    bookToPut.Name = bookToPut.Name;
                    bookToPut.Author = bookToPut.Author;
                    bookToPut.Description = bookToPut.Description;
                    bookToPut.ImgUrl = bookToPut.ImgUrl;
                    bookToPut.IsAvailable = bookToPut.IsAvailable;
                    bookToPut.EBook = bookToPut.EBook;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return NotFound("Il Libro non è stato trovato");
                }
            }
        }
        [HttpGet]
        private IActionResult Details(string v, object modifyBook)
        {
            throw new NotImplementedException();
        }

        public IActionResult Details(int id)
        {
            using (BookContext db = new BookContext())
            {
                Book? bookDetails = db.Libri.Where(book => book.Id == id).FirstOrDefault();
                if (bookDetails != null)
                {
                    return View("Details", bookDetails);
                }
                else
                {
                    return NotFound($"Il Libro con id {id} non è stato trovato!");
                }
            }
        }
    }

}