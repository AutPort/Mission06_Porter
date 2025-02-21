using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Porter.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Porter.Controllers
{
    public class HomeController : Controller
    {
        private MovieListContext _context;

        public HomeController(MovieListContext temp) // constructor
        {
            _context = temp;
        }

        public IActionResult Index() // displays view
        {
            return View();
        }


        public IActionResult JoelInfo() // displays view
        {
            return View();
        }


        [HttpGet]
        public IActionResult MovieList() // displays records from database
        {
            var movie = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movie);
        }


        [HttpGet]
        public IActionResult MovieEntry() // display input boxes to add a new movie to the list
        {            
            ViewBag.categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieEntry", new Movie());
        }

        [HttpPost]
        public IActionResult MovieEntry(Movie response) // saves new movie inputs to database
        {
            response.Category = _context.Categories.Find(response.CategoryId);

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                // Store confirmation message in TempData with movie title
                TempData["SuccessMessage"] = $"Movie \"{response.Title}\" added successfully!";

                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }


        [HttpGet]
        public IActionResult Update(int id) // action to edit/update movie record
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieEntry", recordToEdit);
        }

        [HttpPost]
        public IActionResult Update(Movie updatedInfo) // save updates and return to MovieList view
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Movie updated successfully!";
                return RedirectToAction("MovieList");
            }

            ViewBag.categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieEntry", updatedInfo);
        }


        [HttpGet]
        public IActionResult Delete(int id) // action to select record to delete
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id); // select record according to MovieId

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie) // remove record from database and save changes
        {
            var movieToDelete = _context.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId);

            if (movieToDelete != null)
            {
                string deletedMovieTitle = movieToDelete.Title; // Get the title before deletion

                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Movie \"{deletedMovieTitle}\" deleted successfully!";
            }

            return RedirectToAction("MovieList");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
