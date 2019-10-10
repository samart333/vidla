using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidla.Models;

namespace Vidla.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MemberbershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}