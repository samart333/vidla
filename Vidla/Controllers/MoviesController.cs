using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidla.Models;
using System.Data.Entity;
using Vidla.ViewModels;

namespace Vidla.Controllers
{
    public class MoviesController : Controller
    {

        public ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var genres = _context.Genres.ToList();
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres,
            };

            return View("MovieForm", viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }


            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



        // GET: Movies/Index
        public ActionResult Index()
        {


            //var movies = new MoviesIndexViewModel
            //{
            //    Movies = _context.Movies.Include(c => c.Genre).ToList()
            //};
            return View(/*movies*/);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new MoviesDetailsViewModel();

            viewModel.Movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);


            if (viewModel.Movie == null)
            {
                return View("Error");
            }
            return View(viewModel);
        }
    }
}