using InvoiceManagementSystem.Models;
using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InvoiceManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext appDbContext;

        public CustomersController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IActionResult AllCustomers()
        {
            return View();
        }

        #region AddCustomer_AddBilling_AddShipping_AddContactPerson
        [HttpGet]
        public IActionResult AddCustomers()
        {
            return View();
        }
        [HttpPost]
        public int AddCustomer(CustomersViewModel customersViewModel)
        {
            appDbContext.Add<CustomersViewModel>(customersViewModel);
            appDbContext.SaveChanges();

            //var val = appDbContext.customersViewModels.Where(a => a.Email == customersViewModel.Email);
            //var val1 = appDbContext.customersViewModels.Find(customersViewModel.Email.Where(a=>a.));
            //int id= val1.CustID;
            int userId = appDbContext.Customers
             .Where(m => m.Email == customersViewModel.Email)
               .Select(m => m.CustID)
               .SingleOrDefault();

            return userId;
        }
        [HttpPost]
        public string AddBilling(BillingViewModel billingViewModel)
        {
            appDbContext.Add<BillingViewModel>(billingViewModel);
            appDbContext.SaveChanges();
            return "Bill Created Successfully";
        }
        [HttpPost]
        public string AddShipping(ShippingViewModel shippingViewModel)
        {
            appDbContext.Add<ShippingViewModel>(shippingViewModel);
            appDbContext.SaveChanges();
            return "Shipping Created Successfully";
        }
        [HttpPost]
        public string AddContactPerson(ContactPersonViewModel contactPersonViewModel)
        {
            appDbContext.Add<ContactPersonViewModel>(contactPersonViewModel);
            appDbContext.SaveChanges();
            return "Contact Person Added";
        }
        #endregion
        public IActionResult EditCustomers()
        {
            return View();
        }

        #region CustomersOverviewList
        [HttpGet]
        public IEnumerable<CustomersViewModel> CustomersOverviewList()
        {
            var allCustomers = appDbContext.Customers;
            return allCustomers;

        }
        #endregion

        #region CustomersDeleteList
        [HttpPost]
        public JsonResult CustomersDeleteList(CustomersViewModel objDelete)
        {
            if (objDelete == null)
            {
                return Json("Something went Wrong, Plz Try Again");
            }

            var Customer = appDbContext.Customers.Where(y => y.CustID == objDelete.CustID).FirstOrDefault();
            appDbContext.Customers.Remove(Customer);
            var Billing = appDbContext.Billings.Where(x => x.B_CustID == objDelete.CustID).FirstOrDefault();
            appDbContext.Billings.Remove(Billing);
            var shipping = appDbContext.Shippings.Where(a => a.S_CustID == objDelete.CustID).FirstOrDefault();
            appDbContext.Shippings.Remove(shipping);

            var contactPersons = appDbContext.ContactPerson.Where(x => x.C_P_CustID == objDelete.CustID);
            foreach (var ContactPerson in contactPersons)
            {
                appDbContext.ContactPerson.Remove(ContactPerson);
            }
            appDbContext.SaveChanges();
            return Json("Customers Deleted Successfully");
        }
        #endregion

       
    }
}

