using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidla.Dtos;
using Vidla.Models;

namespace Vidla.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext { };
        }

        //GET/api/movies
        public IHttpActionResult GetCustomers() 
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Created(new Uri(Request.RequestUri + "/"), movies);
        }


        //GET/api/movies/id
        public IHttpActionResult GetCustomer(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            var movieDto = Mapper.Map<Movie, MovieDto>(movie);

            if (movieDto == null)
                return NotFound();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        
        //POST/api/movies
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);

            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //PUT/api/movies/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            Mapper.Map<MovieDto, Movie>(movieDto, movie);

            _context.SaveChanges();


            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //DELETE/api/Movies/id

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                NotFound();

            _context.Movies.Remove(movie);

            _context.SaveChanges();
        }


    }
}
