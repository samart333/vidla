using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidla.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }
    }
}