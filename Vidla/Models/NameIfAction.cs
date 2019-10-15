using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidla.Models
{
    public class LessThan20Years : ValidationAttribute
    {

        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if(movie.GenreId == 0) return ValidationResult.Success;
            if(movie.GenreId == 1) return new ValidationResult("Must input Name");

            var MovieAge = 20 - movie.ReleaseDate.Value.Year;

            return (MovieAge < 20) ? ValidationResult.Success : new ValidationResult("Movie needs to be less than 20 years old");
        }

    }
}