using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManagementSystem.ViewModels;
using InvoiceManagementSystem.Models;

namespace InvoiceManagementSystem.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly AppDbContext appDbContext;

        public InvoicesController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        #region All Invoices
        public IActionResult AllInvoices()
        {
            return View();
        }
        #endregion

        #region New Invoice
        public IActionResult NewInvoices()
        {
            return View();
        }
        #endregion

        #region SalesPersonList
        [HttpGet]
        public IEnumerable<SalesPersonsViewModel> SalesPersonList()
        {
            var allSp = appDbContext.SalesPerson;
            return allSp;
        }
        #endregion

        #region AddSalesPerson
        [HttpPost]
        public JsonResult AddSalesPerson(SalesPersonsViewModel salesPerson)
        {
            if (salesPerson.Name == null && salesPerson.Email == null && salesPerson.ID == 0)
            {
                return Json("Error");
            }
            if ((salesPerson.Name == null || salesPerson.Email == null) && salesPerson.ID == 0)
            {
                return Json("Error");
            }
            appDbContext.Add<SalesPersonsViewModel>(salesPerson);
            appDbContext.SaveChanges();
            return Json("Sales Person Added Successfully");

        }
        #endregion
        [HttpGet]
        public JsonResult DeleteSalesPerson(SalesPersonsViewModel salesPerson)
        {
            if (salesPerson == null)
            {
                return Json("Error");
            }

            var Person = appDbContext.SalesPerson.Where(x => x.ID == salesPerson.ID).FirstOrDefault();
            appDbContext.SalesPerson.Remove(Person);
            appDbContext.SaveChanges();
            return Json("Sales Person Deleted Successfully");
        }

        [HttpGet]
        public JsonResult Invoice_Auto_Generate_Number()
        {
            var maxValue = appDbContext.Invoices.Max(x => x.InvoiceNumber);
            maxValue++;
            return Json(maxValue);
        }

        //[HttpGet]
        //public JsonResult Invoice_Manual_Generate_Number(string obj)
        //{

        //    var result = "dsd";

        //    return Json(result);
        //}

    }
}
