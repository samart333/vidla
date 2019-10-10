using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidla.Models;
using Vidla.ViewModels;
using System.Data.Entity;

namespace Vidla.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomerIndexViewModel();

            viewModel.Customers = _context.Customers.Include(x => x.MembershipType).ToList();


            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new CustomerDetailsViewModel();

            viewModel.Customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == id);
            if (viewModel.Customer == null)
            {
                return View("Error");
            }
            return View(viewModel);
        }

        public List<Customer> GetCustomers()
        {
            var customer1 = new Customer() { Id = 1, Name = "Daniel" };
            var customer2 = new Customer() { Id = 2, Name = "Santiago" };

            var customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);

            return customers;

        }


    }
}