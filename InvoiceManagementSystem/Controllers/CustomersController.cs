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
            int userId = appDbContext.customersViewModels
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
        public IActionResult EditCustomers()
        {

            return View();
        }
    }
}

