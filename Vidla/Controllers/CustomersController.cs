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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers/New
        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MemberbershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customers/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberbershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers/Edit
        public ActionResult Edit(int id)
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                    MemberbershipTypes = membershipTypes,
                    Customer = customer
                };

            return View("CustomerForm", viewModel);
            
        }


        // GET: Customers/Index
        public ActionResult Index()
        {
            var viewModel = new CustomerIndexViewModel();

            viewModel.Customers = _context.Customers.Include(x => x.MembershipType).ToList();


            return View(viewModel);
        }

        // GET: Customers/Details
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