using Microsoft.AspNetCore.Mvc;
using Mission6.Data;
using Mission6.Models;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _context;

        public HomeController(MovieDbContext context)
        {
            _context = context;
        }

        // Home page
        public IActionResult Index()
        {
            return View();
        }

        // "Get to Know Joel" page
        public IActionResult Joel()
        {
            return View();
        }

        // Movie entry form - GET
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        // Movie entry form - POST
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Confirmation");
            }
            return View(movie);
        }

        // Confirmation page after adding a movie
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}