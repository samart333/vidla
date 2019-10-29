using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidla.Models;

namespace Vidla.ViewModels
{
    public class CustomerRentalRecordViewModel
    {

        public Customer customer { get; set; }

        public List<Movie> RentedMovies { get; set; }


    }
}