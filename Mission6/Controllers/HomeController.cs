using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // Add movie form - GET
        [HttpGet]
        public IActionResult AddMovie()
        {
            // Pass categories to the view for the dropdown
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View();
        }

        // Add movie form - POST
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }

            // Repopulate dropdown if validation fails
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(response);
        }

        // View all movies
        public IActionResult ViewMovies()
        {
            // Include Category so we can display CategoryName instead of just the ID
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
        }

        // Edit movie - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            var movie = _context.Movies.Find(id);
            return View("AddMovie", movie);
        }

        // Edit movie - POST
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(updatedMovie);
                _context.SaveChanges();
                return RedirectToAction("ViewMovies");
            }

            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View("AddMovie", updatedMovie);
        }

        // Delete movie - GET (confirmation page)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .FirstOrDefault(m => m.MovieId == id);
            return View(movie);
        }

        // Delete movie - POST
        [HttpPost]
        public IActionResult Delete(Movie movieToDelete)
        {
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();
            return RedirectToAction("ViewMovies");
        }
    }
}