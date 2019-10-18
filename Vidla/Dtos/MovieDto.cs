using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidla.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }


        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }


        [Display(Name = "Number In Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }
    }
}