using MyMVCproject.Models;
using MyMVCproject.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System;
using System.Data.Entity.Validation;

namespace MyMVCproject.Controllers
{
    public class CustomerController : Controller
    {
        #region Private Fields

        private CustomerDBContext _dBContext;

        #endregion

        #region Constructor
        public CustomerController()
        {
            _dBContext = new CustomerDBContext();
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            _dBContext.Dispose();
        }

        #region Actions

        public ActionResult Index()
        {
            var customers = _dBContext.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult CustomerDetails(int id)
        {
            //var customerDetails = _dBContext.Customers
            //    .Include(c => c.MembershipType)
            //    .Where(c => c.Id == id)
            //    .SingleOrDefault();

            var customerDetails = (from c in _dBContext.Customers
                                   join Mt in _dBContext.MembershipTypes
                                   on c.MemberShipTypeId equals Mt.Id
                                   where c.Id == id
                                   select new CustomerDetailsView
                                   {
                                       FirstName = c.FirstName,
                                       LastName = c.LastName,
                                       BirthDay = c.BirthDay,
                                       Email = c.Email,
                                       PhoneNumber = c.PhoneNumber,
                                       DiscountRate = Mt.DiscountRate,
                                       DurationInMonths = Mt.DurationInMonths,
                                       SignUpFee = Mt.SignUpFee,
                                       NameOfMemberShipType = Mt.Name
                                   }
                ).SingleOrDefault();

            if (customerDetails == null)
            {
                return HttpNotFound();
            }

            return View(customerDetails);
        }

        public ActionResult New()
        {
            var membershipTypes = _dBContext.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            var membershipTypes = _dBContext.MembershipTypes.ToList();

            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    MembershipTypes = membershipTypes
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _dBContext.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _dBContext.Customers.Single(c => c.Id == customer.Id);

                /*TryUpdateModel(customerInDb); *///--1 way to Update Model

                customerInDb.FirstName = customer.FirstName;    // ---- 2 way to Update Model
                customerInDb.LastName = customer.LastName;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.Email = customer.Email;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.IsSubscibedToNewletter = customer.IsSubscibedToNewletter;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            }

            _dBContext.SaveChanges();
            
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _dBContext.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _dBContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        #endregion

    }
}