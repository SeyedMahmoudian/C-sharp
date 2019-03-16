using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Lab4.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _movieContext;

        public HomeController(MoviesContext context)
        {
            _movieContext = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_movieContext.Movies.ToList());
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie moive)
        {
            _movieContext.Movies.Add(moive);
            _movieContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditMovie(int id)
        {
            var movieToUpdate = (from c in _movieContext.Movies where c.MovieId == id select c).FirstOrDefault();
            
            return View(movieToUpdate);
        }

        public IActionResult ModifyMovie(Movie movie)
        {
            var id = Convert.ToInt32(Request.Form["MovieId"]);

            var movieToUpdate = (from c in _movieContext.Movies where c.MovieId == id select c).FirstOrDefault();
            movieToUpdate.Title = movie.Title;

            _movieContext.SaveChanges();


            return RedirectToAction("Index");
        }
        public IActionResult DeleteMovie(int id)
        {
            var movieToDelete = (from c in _movieContext.Movies where c.MovieId == id select c).FirstOrDefault();
            _movieContext.Remove(movieToDelete);
            _movieContext.SaveChanges();  
            return RedirectToAction("Index");
        }
    }
}
