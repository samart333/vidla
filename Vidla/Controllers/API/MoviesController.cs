using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _context = new ApplicationDbContext ();
        }

        //GET/api/movies
        public IHttpActionResult GetMovies() 
        {
            var movies = _context.Movies
                            .Include(c => c.Genre)
                            .ToList()
                            .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }


        //GET/api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            var movieDto = Mapper.Map<Movie, MovieDto>(movie);

            if (movieDto == null)
                return NotFound();

            //return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //[Authorize(Roles = RoleName.CanManageMovies)]
        //POST/api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            movieDto.Id = movie.Id;

            _context.Movies.Add(movie);

            _context.SaveChanges();

            


            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //[Authorize(Roles = RoleName.CanManageMovies)]
        //PUT/api/movies/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return BadRequest();

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

            

            _context.SaveChanges();


            //return Created(new Uri(Request.RequestUri + "/" + movieInDb.Id), movieDto);
            return Ok();

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        //DELETE/api/Movies/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                NotFound();

            _context.Movies.Remove(movie);

            _context.SaveChanges();

            return Ok();

        }


    }
}
