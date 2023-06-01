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
    }
}