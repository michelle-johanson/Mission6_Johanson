using Microsoft.AspNetCore.Mvc;
using Mission6.Data;
using Mission6.Models;

namespace Mission6.Controllers
{
    public class HomeController : Controller // Inherits the Controller class
    {
        private readonly MovieDbContext _context;

        public HomeController(MovieDbContext context) // Constructor
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
        public IActionResult AddMovie(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirmation", response); // takes user to confirmation view after submission
        }

        public IActionResult ViewMovies()
        {
            // Linq
            var movies = _context.Movies
                .Where(x => x.Edited == false)
                .OrderBy(x => x.Title).ToList();
            
            return View(movies);
        }
    }
}