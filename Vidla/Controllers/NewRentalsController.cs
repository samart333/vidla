using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidla.Dtos;
using Vidla.Models;

namespace Vidla.Controllers
{
    public class NewRentalsController : ApiController
    {

        public ApplicationDbContext _context { get; set; }

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //POST/api/movies
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            //Id's of rented movies
            var movies = _context.Movies.Where(movie => newRental.MovieIds.Contains(movie.Id));

            //client that does the request
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);



            foreach (var movie in movies)
            {

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();

            
        }

    }
}
