using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Porter.Models;

namespace Mission06_Porter.Controllers
{
    public class HomeController : Controller
    {
        private MovieListContext _context;

        public HomeController(MovieListContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JoelInfo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieList(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            // Log errors for debugging purposes
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(response); // Return the model with errors
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
