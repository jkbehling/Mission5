using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            _context = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        public IActionResult ListMovies()
        {
            var movies = _context.Responses.Include(x => x.Category).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieResponse ar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ar);
                _context.SaveChanges();
                return View("MovieAdded", ar);
            }
            else //if Invalid
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View();
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Edit (int MovieID)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var movie = _context.Responses.Single(x => x.MovieID == MovieID);
            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit (MovieResponse ar)
        {
            _context.Update(ar);
            _context.SaveChanges();
            return RedirectToAction("ListMovies");
        }

        [HttpGet]
        public IActionResult Delete (int MovieID)
        {
            var movie = _context.Responses.Single(x => x.MovieID == MovieID);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            _context.Responses.Remove(mr);
            _context.SaveChanges();
            return RedirectToAction("ListMovies");
        }
    }
}
