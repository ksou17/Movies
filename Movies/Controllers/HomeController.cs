using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
       

        private Context MovieContext { get; set; }

        public HomeController(Context Name)
        {
            
            MovieContext = Name;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = MovieContext.Categories.ToList();
            
            return View();
        }
        [HttpPost]
        public IActionResult Movies(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(mr);
            MovieContext.SaveChanges();
            return View("Confirmation", mr);
            }
            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View(mr);
            }
            
            
        }

        public IActionResult List ()
        {
           var Movie = MovieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.MovieTitle)
                .ToList();

            return View(Movie);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var movie = MovieContext.Responses.Single(x => x.MovieID == movieid);

            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse mr)
        {
            MovieContext.Update(mr);
            MovieContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var application = MovieContext.Responses.Single(x => x.MovieID == movieid);
            return View(application);
        }
        [HttpPost]
        public IActionResult Delete (MovieResponse mr)
        {
            MovieContext.Responses.Remove(mr);
            MovieContext.SaveChanges();
            return RedirectToAction("List");
        }

        
    }
}
