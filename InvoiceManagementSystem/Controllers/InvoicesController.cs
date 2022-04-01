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
        private readonly AppDbContext appDbContext1;
        public InvoicesController(AppDbContext appDbContext)
        {
            this.appDbContext1 = appDbContext;
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

        #region Sales Person Add
        [HttpGet]
        public IActionResult SalesPersons()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SalesPersons(SalesPersonsViewModel salesPersonsViewModel)
        {
            var search = appDbContext1.SalesPerson.Where(s => s.Email == salesPersonsViewModel.Email).FirstOrDefault();
            var err = "Sales Person is already exist";
            if (search == null)
            {
                appDbContext1.SalesPerson.Add(salesPersonsViewModel);
                appDbContext1.SaveChanges();
                var saleperson = appDbContext1.SalesPerson.Where(s => s.Email == salesPersonsViewModel.Email).FirstOrDefault();
                return Json(saleperson);
            }
            return Json(err);
               
            

        }
        #endregion


        #region Sales Persons Select All
        [HttpGet]
        public JsonResult SalesPersonList()
        {
            return Json(appDbContext1.SalesPerson.ToList());
        }
        #endregion

        //#region Sales Persons Update
        //public JsonResult SalesPersonUpdate(SalesPersonsViewModel salesPersonsViewModel)
        //{
        //    var data = appDbContext1.SalesPerson.FirstOrDefault(s => s.ID == salesPersonsViewModel.ID);
        //    if (data !=null)
        //    {
        //        data.Name = salesPersonsViewModel.Name;
        //        data.Email = salesPersonsViewModel.Email;
        //        appDbContext1.SaveChanges();
        //    }
        //    return Json(salesPersonsViewModel);
        //}
        //#endregion
        //public JsonResult SalesPersonsByID(int ID)
        //{
        //    return Json(appDbContext1.SalesPerson.FirstOrDefault(s => s.ID == ID));
        //}
    }
}

