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
        // GET: Movies
        public ActionResult Index()
        {
            var viewModel = new MoviesIndexViewModel();

             viewModel.Movies = _context.Movies.Include(x => x.Genre).ToList();
            return View(viewModel);
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